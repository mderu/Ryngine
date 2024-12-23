using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using AntlrRenpy.Program;
using AntlrRenpy.Program.ControlFlows;
using AntlrRenpy.Program.Expressions;
using AntlrRenpy.Program.Expressions.Operators;
using AntlrRenpy.Program.Instructions;
using System.Text;
using static RenpyParser;

namespace AntlrRenpy.Listener
{
    public partial class RenpyListener : RenpyParserBaseListener
    {
        private readonly Stack<IExpression> expressionStack = [];
        private readonly Stack<Block> blockStack = [];

        public Script Script { get; private init; } = new();

        public override void EnterEntire_tree([NotNull] Entire_treeContext context)
        {
            // Always add a pass statement so scripts that start with a label have a root instruction
            // to point to.
            blockStack.Push(new([new Pass()]));
        }

        public override void ExitEntire_tree([NotNull] Entire_treeContext context)
        {
            Stack<Block> reorganizedBlocks = new(blockStack.Count);
            while (blockStack.Count > 0)
            {
                reorganizedBlocks.Push(blockStack.Pop());
            }

            while (reorganizedBlocks.Count > 0)
            {
                Block block = reorganizedBlocks.Pop();
                foreach (IInstruction instruction in block.Instructions)
                {
                    Script.AppendInstruction(instruction);
                }
            }

            // Avoid having resulting expressions accumulate memory.
            // Expressions should always be confined to its statement.
            if (expressionStack.Count > 0)
            {
                throw new Exception("Expressions have leaked.");
            }
        }

        public override void EnterPass_statement([NotNull] Pass_statementContext context)
        {
            AppendInstruction(new Pass());
        }

        public override void EnterReturn_simple([NotNull] Return_simpleContext context)
        {
            AppendInstruction(new ReturnSimple());
        }

        public override void ExitJump([NotNull] JumpContext context)
        {
            if (context.label_name() is not null)
            {
                Constant<string> labelName = new(context.label_name().GetText());
                AppendInstruction(new Jump(labelName));
            }
            else if (context.EXPRESSION() is not null)
            {
                AppendInstruction(new Jump(expressionStack.Pop()));
            }
            else
            {
                throw new NotImplementedException($"Uncertain what to do with jump {context}");
            }
        }

        public override void ExitCall([NotNull] CallContext context)
        {
            Arguments arguments = context.arguments() is not null
                    ? (Arguments)expressionStack.Pop()
                    : new();
            string labelName = context.label_name().GetText();
            AppendInstruction(new PushFrame(labelName, arguments));
        }

        public override void ExitLabel([NotNull] LabelContext context)
        {
            string labelName = context.label_name().GetText();
            IInstruction lastInstruction = GetPreviousInstruction();
            InsertLabel(labelName, lastInstruction, context.parameters(), jumpToAfterInstruction: true);
        }

        public override void EnterSay([NotNull] SayContext context)
        {
            string text = StringParser.Parse(context.STRING().GetText());
            string speaker = context.NAME() is null ? "" : context.NAME().GetText();

            AppendInstruction(
                new Say(text)
                {
                    Speaker = speaker,
                }
            );
        }

        public override void ExitAtom([NotNull] AtomContext context)
        {
            if (context.strings() is not null)
            {
                // handled by EnterStrings.
            }
            else if (context.NAME() is not null)
            {
                expressionStack.Push(new NamedStore(context.NAME().GetText()));
            }
            else if (context.TRUE() is not null)
            {
                expressionStack.Push(new Constant<bool>(true));
            }
            else if (context.FALSE() is not null)
            {
                expressionStack.Push(new Constant<bool>(false));
            }
            else if (context.NONE() is not null)
            {
                expressionStack.Push(new Null());
            }
            else if (context.NUMBER() is not null)
            {
                // Claim type is decimal. Doesn't really matter for parsing.
                expressionStack.Push(new ConstantNumber(context.NUMBER().GetText()));
            }
            else if (context.list() is not null)
            {
                // No action needed, covered by ExitList
            }
            else if (context.dict() is not null)
            {
                // No action needed, covered by ExitDict
            }
            else
            {
                throw new NotImplementedException($"Unsure what to do with {context.GetText()}");
            }
        }

        public override void ExitT_primary([NotNull] T_primaryContext context)
        {
            if (context.ChildCount == 1 && context.NAME() is not null)
            {
                expressionStack.Push(new NamedStore(context.NAME().GetText()));
            }
            else if (context.NAME() is not null)
            {
                IExpression baseExpression = expressionStack.Pop();
                expressionStack.Push(new MemberAccess(baseExpression, context.NAME().GetText()));
            }
            else if (context.arguments() is not null)
            {
                if (context.arguments().ChildCount == 1)
                {
                    IExpression baseExpression = expressionStack.Pop();
                    IExpression arguments = expressionStack.Pop();
                    expressionStack.Push(new Call(baseExpression, arguments));
                }
                else
                {
                    // TODO: Pass an empty args object.
                }
            }
            else if (context.slices() is not null)
            {
                IExpression baseExpression = expressionStack.Pop();
                IExpression sliceExpression = expressionStack.Pop();
                expressionStack.Push(new SubscriptAccess(baseExpression, sliceExpression));
            }
            else
            {
                throw new NotImplementedException($"Rule `primary` currently doesn't support {context.GetText()}");
            }
        }

        public override void ExitPrimary([NotNull] PrimaryContext context)
        {
            if (context.atom() is not null)
            {
                // Covered by ExitAtom.
            }
            else if (context.NAME() is not null)
            {
                IExpression baseExpression = expressionStack.Pop();
                expressionStack.Push(new MemberAccess(baseExpression, context.NAME().GetText()));
            }
            else if (context.arguments() is not null)
            {
                if (context.arguments().ChildCount == 1)
                {
                    IExpression baseExpression = expressionStack.Pop();
                    IExpression arguments = expressionStack.Pop();
                    expressionStack.Push(new Call(baseExpression, arguments));
                }
                else
                {
                    // TODO: Pass an empty args object.
                }
            }
            else if (context.slices() is not null)
            {
                IExpression baseExpression = expressionStack.Pop();
                IExpression sliceExpression = expressionStack.Pop();
                expressionStack.Push(new Call(baseExpression, sliceExpression));
            }
            else
            {
                throw new NotImplementedException($"Rule `primary` currently doesn't support {context.GetText()}");
            }
        }

        public override void ExitSum([NotNull] SumContext context)
        {
            if (context.sum() is not null)
            {
                if (context.PLUS() is not null)
                {
                    IExpression rhs = expressionStack.Pop();
                    IExpression lhs = expressionStack.Pop();
                    expressionStack.Push(new Add(lhs, rhs));
                }
                else if (context.MINUS() is not null)
                {
                    // Negate instead of subtraction. Haven't thought too much about
                    // what that would do for integer edge cases.
                    IExpression rhs = new Negate(expressionStack.Pop());
                    IExpression lhs = expressionStack.Pop();
                    expressionStack.Push(new Add(lhs, rhs));
                }
                else
                {
                    throw new NotImplementedException("Recursive `sum` reached, but PLUS and MINUS are missing.");
                }
            }
            else if (context.primary() is not null)
            {
                // Covered by ExitPrimary()
            }
            else
            {
                throw new NotImplementedException($"Rule `sum` currently doesn't support {context.GetText()}");
            }
        }

        public override void ExitAssignment_expression([NotNull] Assignment_expressionContext context)
        {
            expressionStack.Push(new AssignmentExpression(context.NAME().GetText(), expressionStack.Pop()));
        }

        public override void ExitStrings([NotNull] StringsContext context)
        {
            StringBuilder stringBuilder = new();
            foreach (var str in context.STRING())
            {
                stringBuilder.Append(StringParser.Parse(str.GetText()));
            }
            expressionStack.Push(new Constant<string>(stringBuilder.ToString()));
        }

        public override void ExitSingle_target([NotNull] Single_targetContext context)
        {
            if (context.single_subscript_attribute_target() is not null)
            {
                //Handled by ExitSingle_subscript_attribute_target.
            }
            else if (context.NAME() is not null)
            {
                expressionStack.Push(new NamedStore(context.NAME().GetText()));
            }
        }

        public override void ExitSingle_subscript_attribute_target(
            [NotNull] Single_subscript_attribute_targetContext context)
        {
            if (context.NAME() is not null)
            {
                expressionStack.Push(new MemberAccess(expressionStack.Pop(), context.NAME().GetText()));
            }
            else if (context.slices() is not null)
            {
                IExpression sliceExpression = expressionStack.Pop();
                IExpression baseExpression = expressionStack.Pop();
                expressionStack.Push(new SubscriptAccess(sliceExpression, baseExpression));
            }
        }

        public override void ExitAssignment([NotNull] AssignmentContext context)
        {
            if (context.EQUALS() is not null)
            {
                IExpression rhs = expressionStack.Pop();
                IExpression lhs = expressionStack.Pop();
                AppendInstruction(new Assignment(lhs, Assignment.Type.Equal, rhs));
            }
            else if (context.augassign() is AugassignContext augassign)
            {
                IExpression rhs = expressionStack.Pop();
                IExpression lhs = expressionStack.Pop();

                Assignment.Type assignmentType = augassign.GetText() switch
                {
                    "+=" => Assignment.Type.PlusEqual,
                    "-=" => Assignment.Type.MinEqual,
                    "*=" => Assignment.Type.StarEqual,
                    "/=" => Assignment.Type.SlashEqual,
                    "%=" => Assignment.Type.PercentEqual,
                    "&=" => Assignment.Type.AmperEqual,
                    "|=" => Assignment.Type.VbarEqual,
                    "^=" => Assignment.Type.CircumflexEqual,
                    "<<=" => Assignment.Type.LeftShiftEqual,
                    ">>=" => Assignment.Type.RightShiftEqual,
                    "**=" => Assignment.Type.DoubleStarEqual,
                    "//=" => Assignment.Type.DoubleSlashEqual,
                    _ => throw new NotImplementedException(),
                };

                AppendInstruction(new Assignment(lhs, assignmentType, rhs));
            }
            else
            {
                throw new NotImplementedException($"Rule `assignment` currently doesn't support {context.GetText()}");
            }
        }

        public override void ExitComparison([NotNull] ComparisonContext context)
        {
            if (context.bitwise_or().Length == 2)
            {
                Comparison.Type comparisonType = context.children[1].GetText() switch
                {
                    "not" => Comparison.Type.NotIn,
                    "==" => Comparison.Type.IsEqualTo,
                    "!=" => Comparison.Type.IsNotEqualTo,
                    "<=" => Comparison.Type.LessThanOrEqual,
                    ">=" => Comparison.Type.GreaterThanOrEqual,
                    "in" => Comparison.Type.In,
                    "is" => context.children.Count == 3
                        ? Comparison.Type.Is
                        : Comparison.Type.IsNot,
                    "<" => Comparison.Type.LessThan,
                    ">" => Comparison.Type.GreaterThan,
                    _ => throw new NotImplementedException(),
                };

                IExpression rhs = expressionStack.Pop();
                IExpression lhs = expressionStack.Pop();

                expressionStack.Push(new Comparison(lhs, comparisonType, rhs));
            }
        }

        private void InsertLabel(
            string labelName,
            IInstruction instruction,
            ParametersContext? parametersContext,
            bool jumpToAfterInstruction = false)
        {
            Parameters parameters = parametersContext is not null
                ? (Parameters)expressionStack.Pop()
                : new Parameters([], [], 0, 0);

            Label label = new(labelName, parameters, instruction, jumpToAfterInstruction);
            Script.InsertLabel(label);
        }

        private IInstruction AppendInstruction(IInstruction instruction)
        {
            blockStack.Peek().Instructions.Add(instruction);
            return instruction;
        }

        private IInstruction GetPreviousInstruction()
        {
            foreach (Block block in blockStack)
            {
                if (block.Instructions.Count > 0)
                {
                    return block.Instructions[^1];
                }
            }
            throw new InvalidOperationException("There are no instructions in the block stack.");
        }
    }
}
