using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
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
        private Stack<Menu.Builder> menuBuilderStack = new();
        private Stack<MenuItem.Builder> menuItemBuilderStack = new();
        private Stack<IExpression> expressionStack = new();

        public Script Script { get; private init; } = new();

        public override void EnterPass_statement([NotNull] Pass_statementContext context)
        {
            Script.AppendInstruction(new Pass());
        }

        public override void EnterReturn_simple([NotNull] Return_simpleContext context)
        {
            Script.AppendInstruction(new ReturnSimple());
        }

        public override void EnterJump_constant([NotNull] Jump_constantContext context)
        {
            Script.AppendInstruction(new JumpConstant(context.label_name().GetText()));
        }

        public override void EnterCall_constant([NotNull] Call_constantContext context)
        {
            Script.AppendInstruction(new CallConstant(context.label_name().GetText()));
        }

        public override void EnterLabel_constant([NotNull] Label_constantContext context)
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
                    expressionStack.Push(new Add(expressionStack.Pop(), expressionStack.Pop()));
                }
                else if (context.MINUS() is not null)
                {
                    // Negate instead of subtraction. Haven't thought too much about
                    // what that would do for integer edge cases.
                    IExpression lhs = new Negate(expressionStack.Pop());
                    IExpression rhs = expressionStack.Pop();
                    expressionStack.Push(new Add(rhs, lhs));
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

        public override void ExitStrings([NotNull] StringsContext context)
        {
            StringBuilder stringBuilder = new();
            foreach (var str in context.STRING())
            {
                stringBuilder.Append(StringParser.Parse(str.GetText()));
            }
            expressionStack.Push(new Constant<string>(stringBuilder.ToString()));
        }

        public override void ExitAssignment_rhs([NotNull] Assignment_rhsContext context)
        {
            if (context.assignment_rhs() is not null)
            {
                if (context.NAME() is not null)
                {
                    expressionStack.Push(new MemberAccess(expressionStack.Pop(), context.NAME().GetText()));
                }
                else
                {
                    throw new NotImplementedException("Recursive `assignment_rhs` reached, but NAME is missing.");
                }
            }
            else if (context.NAME() is not null)
            {
                expressionStack.Push(new NamedStore(context.NAME().GetText()));
            }
            else
            {
                throw new NotImplementedException($"Rule `assignment_rhs` currently doesn't support {context.GetText()}");
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
