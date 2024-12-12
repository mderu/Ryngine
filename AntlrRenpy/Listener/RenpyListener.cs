using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using AntlrRenpy.Program;
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
        private readonly Queue<Parameter> parameterQueue = [];
        private readonly Stack<int> labelStartStack = [];

        public Script Script { get; private init; } = new();

        public override void ExitStatement([NotNull] StatementContext context)
        {
            // Avoid having resulting expressions accumulate memory.
            // Expressions should always be confined to its statement.
            if (expressionStack.Count > 0)
            {
                throw new Exception("Expressions have leaked.");
            }
        }

        public override void EnterPass_statement([NotNull] Pass_statementContext context)
        {
            Script.AppendInstruction(new Pass());
        }

        public override void EnterReturn_simple([NotNull] Return_simpleContext context)
        {
            Script.AppendInstruction(new ReturnSimple());
        }

        public override void ExitJump_constant([NotNull] Jump_constantContext context)
        {
            Script.AppendInstruction(new JumpConstant(expressionStack.Pop()));
        }

        public override void ExitCall([NotNull] CallContext context)
        {
            Arguments arguments = context.arguments() is not null
                    ? (Arguments)expressionStack.Pop()
                    : new();
            string labelName = context.label_name().GetText();
            Script.AppendInstruction(new PushFrame(labelName, arguments));
        }

        public override void ExitParam_no_default([NotNull] Param_no_defaultContext context)
        {
            string parameterName = context.param().NAME().GetText();
            parameterQueue.Enqueue(new Parameter(parameterName));
        }

        public override void ExitParam_with_default([NotNull] Param_with_defaultContext context)
        {
            string parameterName = context.param().NAME().GetText();
            IExpression defaultValue = expressionStack.Pop();
            parameterQueue.Enqueue(new Parameter(parameterName, defaultValue));
        }

        public override void EnterParameters([NotNull] ParametersContext context)
        {
            if (parameterQueue.Count > 0)
            {
                throw new InvalidOperationException("Began parameters with items still in the parameter queue.");
            }
        }

        public override void ExitParameters([NotNull] ParametersContext context)
        {
            List<string> paramNames = [];
            Dictionary<string, IExpression> defaultValues = [];

            while (parameterQueue.Count > 0)
            {
                Parameter curParam = parameterQueue.Dequeue();
                paramNames.Add(curParam.Name);

                if (curParam.DefaultValue is not null)
                {
                    defaultValues[curParam.Name] = curParam.DefaultValue;
                }
            }

            int numPositionalParameters = 0;
            int numNameOnlyParameters = 0;
            for (int i = 0; i < context.ChildCount; i++)
            {
                if (context.children[i] == context.SLASH())
                {
                    numPositionalParameters = i - 1;
                }
                else if (context.children[i] == context.STAR())
                {
                    numNameOnlyParameters = context.ChildCount - i - 1;

                    // Subtract the non-parameters ('/' ',') if they were present.
                    if (numPositionalParameters > 0)
                    {
                        numNameOnlyParameters -= 2;
                    }
                }
            }

            expressionStack.Push(new Parameters(paramNames, defaultValues, numPositionalParameters, numNameOnlyParameters));
        }

        public override void EnterLabel([NotNull] LabelContext context)
        {
            labelStartStack.Push(Script.NextInstructionIndex);
        }

        public override void ExitLabel([NotNull] LabelContext context)
        {
            string labelName = context.label_name().GetText();
            InsertLabel(labelName, context.parameters());
        }

        public override void EnterSay([NotNull] SayContext context)
        {
            string text = StringParser.Parse(context.STRING().GetText());
            string speaker = context.NAME() is null ? "" : context.NAME().GetText();

            Script.AppendInstruction(
                new Say(text)
                {
                    Speaker = speaker,
                }
            );
        }

        public override void EnterMenu([NotNull] MenuContext context)
        {
            var labelNameContext = context.label_name();
            if (labelNameContext is not null)
            {
                labelStartStack.Push(Script.NextInstructionIndex);
            }

            Menu.Builder newMenuBuilder = new(Script.Instructions.Count);
            Script.AppendInstruction(new Placeholder<Menu>(newMenuBuilder));

            // https://www.renpy.org/doc/html/menus.html#menu-set
            // The "set" clause is technically not an instruction, so if the
            // say instruction is present, it's safe to assume it will be the
            // next instruction. Ren'Py's documentation doesn't specify that it
            // allows screen directives here.
            //
            // I do see some scripts use:
            //
            //     menu:
            //         with expression
            //         "First option"
            //
            // Might look into the expected behavior here in the future, but the
            // "with" clause is also not an instruction, and is a clause on a say.
            if (context.say() is not null)
            {
                newMenuBuilder.SetSayInstructionIndex(Script.Instructions.Count);
            }

            menuBuilderStack.Push(newMenuBuilder);
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

        public override void ExitArgs([NotNull] ArgsContext context)
        {
            Arguments? kwargs = null;
            Stack<IExpression> argStack = [];
            if (context.kwargs() is not null)
            {
                kwargs = (Arguments)expressionStack.Pop();
            }

            int totalOrderedArgs = context.starred_expression().Length
                + context.assignment_expression().Length
                + context.expression().Length;

            for (int index = totalOrderedArgs; index > 0; index--)
            {
                argStack.Push(expressionStack.Pop());
            }

            expressionStack.Push(new Arguments(
                arguments: [.. argStack, .. kwargs?.OrderedArguments ?? []],
                keywordArguments: kwargs?.KeywordArguments));
        }

        public override void ExitKwargs([NotNull] KwargsContext context)
        {
            Stack<IExpression> args = [];
            Stack<IExpression> kwargs = [];
            int expressionCount = context.kwarg_or_double_starred().Length + context.kwarg_or_starred().Length;
            for (int index = expressionCount; index > 0; index--)
            {
                IExpression expression = expressionStack.Pop();

                (expression switch
                {
                    UnaryStar _ => args,
                    NamedArgument _ => kwargs,
                    UnaryDoubleStar _ => kwargs,
                    _ => throw new InvalidCastException($"Uncertain what type of argument {expression.GetType()} is."),
                }).Push(expressionStack.Pop());
            }

            // Stacks iterate in Pop() order. This flips the args & kwargs.
            expressionStack.Push(new Arguments([.. args], [.. kwargs]));
        }

        public override void ExitKwarg_or_starred([NotNull] Kwarg_or_starredContext context)
        {
            if (context.NAME() is ITerminalNode node)
            {
                expressionStack.Push(new NamedArgument(node.GetText(), expressionStack.Pop()));
            }
            // starred_expression can remain in the stack.
        }

        public override void ExitKwarg_or_double_starred([NotNull] Kwarg_or_double_starredContext context)
        {
            if (context.NAME() is ITerminalNode node)
            {
                expressionStack.Push(new NamedArgument(node.GetText(), expressionStack.Pop()));
            }
            else if (context.DOUBLESTAR() is not null)
            {
                expressionStack.Push(new UnaryDoubleStar(expressionStack.Pop()));
            }
        }

        public override void ExitStarred_expression([NotNull] Starred_expressionContext context)
        {
            expressionStack.Push(new UnaryStar(expressionStack.Pop()));
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
                IExpression lhs = expressionStack.Pop();
                IExpression rhs = expressionStack.Pop();
                Script.AppendInstruction(new Assignment(rhs, lhs));
            }
            else
            {
                throw new NotImplementedException($"Rule `assignment` currently doesn't support {context.GetText()}");
            }
        }

        private void InsertLabel(string labelName, ParametersContext? parametersContext)
        {
            int instructionIndex = labelStartStack.Pop();
            Parameters parameters = parametersContext is not null
                ? (Parameters)expressionStack.Pop()
                : new Parameters([], [], 0, 0);

            Label label = new(labelName, parameters, instructionIndex);
            Script.InsertLabel(label);
        }
    }
}
