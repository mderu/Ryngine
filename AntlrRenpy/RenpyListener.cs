using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using AntlrRenpy.Program;
using AntlrRenpy.Program.Expressions;
using AntlrRenpy.Program.Expressions.Operators;
using AntlrRenpy.Program.Instructions;
using System.Text;
using static RenpyParser;

namespace AntlrRenpy
{
    public class RenpyListener : RenpyParserBaseListener
    {
        private readonly Stack<Menu.Builder> menuBuilderStack = new();
        private readonly Stack<MenuItem.Builder> menuItemBuilderStack = new();
        private readonly Stack<IExpression> expressionStack = new();

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
            IExpression arguments = (context.arguments() is not null
                && context.arguments().ChildCount > 0)
                    ? expressionStack.Pop()
                    : new Arguments();
            string labelName = context.label_name().GetText();
            Script.AppendInstruction(new PushFrame(labelName, arguments));
        }

        public override void EnterLabel([NotNull] LabelContext context)
        {
            Script.InsertLabel(context.label_name().GetText());
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
                Script.InsertLabel(context.label_name().GetText());
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

        public override void ExitMenu([NotNull] MenuContext context)
        {
            Menu.Builder builder = menuBuilderStack.Pop();

            Menu menu = builder.Build();

            Script.ReplacePlaceholder(builder.SelfInstructionIndex, builder, menu);
        }

        public override void EnterMenu_item([NotNull] Menu_itemContext context)
        {
            string caption = StringParser.Parse(context.STRING().GetText());
            int startingIndex = Script.Instructions.Count;

            MenuItem.Builder builder = new();
            builder.SetCaption(caption);
            builder.SetStartInstructionIndex(startingIndex);
            menuItemBuilderStack.Push(builder);
        }

        public override void ExitMenu_item([NotNull] Menu_itemContext context)
        {
            MenuItem.Builder builder = menuItemBuilderStack.Pop();

            builder.SetEndInstructionIndex(Script.Instructions.Count);

            menuBuilderStack.Peek().AddMenuItem(builder.Build());
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
    }
}
