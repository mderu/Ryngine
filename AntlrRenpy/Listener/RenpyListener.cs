using Antlr4.Runtime.Misc;
using AntlrRenpy.Program;
using AntlrRenpy.Program.ControlFlows;
using AntlrRenpy.Program.Expressions;
using AntlrRenpy.Program.Expressions.Operators;
using AntlrRenpy.Program.Instructions;
using AntlrRenpy.Program.Clauses;
using System.Text;
using static RenpyParser;
using System.Runtime.CompilerServices;
using Antlr4.Runtime.Tree;

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

        public override void ExitExpression_as_statement([NotNull] Expression_as_statementContext context)
        {
            AppendInstruction(new ExpressionAsInstruction(expressionStack.Pop()));
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
                // TODO: Should this be a NamedStore instead?
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
            else if (context.name() is not null)
            {
                expressionStack.Push(new NamedStore(context.name().GetText()));
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
            if (context.ChildCount == 1 && context.name() is not null)
            {
                expressionStack.Push(new NamedStore(context.name().GetText()));
            }
            else if (context.name() is not null)
            {
                IExpression baseExpression = expressionStack.Pop();
                expressionStack.Push(new MemberAccess(baseExpression, context.name().GetText()));
            }
            else if (context.arguments() is not null)
            {
                if (context.arguments().ChildCount == 1)
                {
                    IExpression arguments = expressionStack.Pop();
                    IExpression baseExpression = expressionStack.Pop();
                    expressionStack.Push(new Call(baseExpression, arguments));
                }
                else
                {
                    // TODO: Pass an empty args object.
                }
            }
            else if (context.slices() is not null)
            {
                IExpression sliceExpression = expressionStack.Pop();
                IExpression baseExpression = expressionStack.Pop();
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
            else if (context.name() is not null)
            {
                IExpression baseExpression = expressionStack.Pop();
                expressionStack.Push(new MemberAccess(baseExpression, context.name().GetText()));
            }
            else if (context.LPAR() is not null)
            {
                if (context.arguments() is not null)
                {
                    IExpression arguments = expressionStack.Pop();
                    IExpression baseExpression = expressionStack.Pop();
                    expressionStack.Push(new Call(baseExpression, arguments));
                }
                else
                {
                    IExpression baseExpression = expressionStack.Pop();
                    expressionStack.Push(new Call(baseExpression, new Arguments()));
                }
            }
            else if (context.slices() is not null)
            {
                IExpression sliceExpression = expressionStack.Pop();
                IExpression baseExpression = expressionStack.Pop();
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
            expressionStack.Push(new AssignmentExpression(context.name().GetText(), expressionStack.Pop()));
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
            else if (context.name() is not null)
            {
                expressionStack.Push(new NamedStore(context.name().GetText()));
            }
        }

        public override void ExitSingle_subscript_attribute_target(
            [NotNull] Single_subscript_attribute_targetContext context)
        {
            if (context.name() is not null)
            {
                expressionStack.Push(new MemberAccess(expressionStack.Pop(), context.name().GetText()));
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

        public override void ExitDefault([NotNull] DefaultContext context)
        {
            IExpression rhs = expressionStack.Pop();
            IExpression lhs = expressionStack.Pop();
            AppendInstruction(new Default(lhs, rhs));
        }

        public override void ExitDefine([NotNull] DefineContext context)
        {
            IExpression rhs = expressionStack.Pop();
            IExpression lhs = expressionStack.Pop();
            AppendInstruction(new Define(lhs, rhs));
        }

        public override void ExitComparison([NotNull] ComparisonContext context)
        {
            if (context.comparison() is not null)
            {
                Comparison.Type comparisonType = context.comparison_operator().GetText() switch
                {
                    "isnot" => Comparison.Type.IsNot,
                    "notin" => Comparison.Type.NotIn,
                    "==" => Comparison.Type.IsEqualTo,
                    "!=" => Comparison.Type.IsNotEqualTo,
                    "<=" => Comparison.Type.LessThanOrEqual,
                    ">=" => Comparison.Type.GreaterThanOrEqual,
                    "in" => Comparison.Type.In,
                    "is" => Comparison.Type.Is,
                    "<" => Comparison.Type.LessThan,
                    ">" => Comparison.Type.GreaterThan,
                    _ => throw new NotImplementedException(),
                };

                IExpression rhs = expressionStack.Pop();
                IExpression lhs = expressionStack.Pop();

                expressionStack.Push(new Comparison(lhs, comparisonType, rhs));
            }
        }

        public override void ExitWindow([NotNull] WindowContext context)
        {
            Transition? transition = null;
            if (context.expression() is not null)
            {
                transition = new Transition(expressionStack.Pop());
            }


            bool show = false;
            if (context.SHOW() is not null)
            {
                if (context.HIDE() is not null)
                {
                    throw new InvalidOperationException("`show` and `hide` are both not present.");
                }
                show = true;
            }

            AppendInstruction(new Window(show, transition));
        }

        public override void ExitScene([NotNull] SceneContext context)
        {
            (IExpression displayableExpression, Transition? transition) = GetDisplayableChange(
                names: context.NAME(),
                hasWithClause: context.WITH() is not null,
                hasExpressionClause: context.EXPRESSION() is not null);
            
            AppendInstruction(new Scene(displayableExpression, transition));
        }

        public override void ExitShow([NotNull] ShowContext context)
        {
            (IExpression displayableExpression, Transition? transition) = GetDisplayableChange(
                names: context.NAME(),
                hasWithClause: context.WITH() is not null,
                hasExpressionClause: context.EXPRESSION() is not null);

            AppendInstruction(new Show(displayableExpression, transition));
        }

        public override void ExitHide([NotNull] HideContext context)
        {
            (IExpression displayableExpression, Transition? transition) = GetDisplayableChange(
                names: context.NAME(),
                hasWithClause: context.WITH() is not null,
                hasExpressionClause: context.EXPRESSION() is not null);

            AppendInstruction(new Hide(displayableExpression, transition));
        }

        private (IExpression displayableExpression, Transition? transistion) 
            GetDisplayableChange(ITerminalNode[] names, bool hasWithClause, bool hasExpressionClause)
        {
            Transition? transition = null;
            if (hasWithClause)
            {
                transition = new(expressionStack.Pop());
            }

            IExpression displayableExpression;
            if (names.Length > 0)
            {
                displayableExpression = new Displayable(
                    Name: names[0].GetText(),
                    Properties: names.Skip(1).Select(item => item.GetText()).ToArray()
                );
            }
            else if (hasExpressionClause)
            {
                displayableExpression = expressionStack.Pop();
            }
            else
            {
                throw new InvalidOperationException("Unhandled `scene` statement case.");
            }

            return (displayableExpression, transition);
        }

        public override void ExitPause([NotNull] PauseContext context)
        {
            AppendInstruction(new Pause());
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
