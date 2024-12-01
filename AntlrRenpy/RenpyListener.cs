using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using AntlrRenpy.Program;
using AntlrRenpy.Program.Instructions;
using static RenpyParser;

namespace AntlrRenpy
{
    public class RenpyListener : RenpyParserBaseListener
    {
        private Stack<Menu.Builder> menuBuilderStack = new();
        private Stack<MenuItem.Builder> menuItemBuilderStack = new();

        public Script Script { get; private init; } = new();

        public override void EnterEntire_tree([NotNull] Entire_treeContext context)
        {
            base.EnterEntire_tree(context);
        }

        public override void EnterStatement([NotNull] StatementContext context)
        {
            base.EnterStatement(context);
        }

        public override void EnterPass_statement([NotNull] Pass_statementContext context)
        {
            Script.AppendInstruction(new Pass());
            base.EnterPass_statement(context);
        }

        public override void EnterReturn_simple([NotNull] Return_simpleContext context)
        {
            Script.AppendInstruction(new ReturnSimple());
            base.EnterReturn_simple(context);
        }

        public override void EnterJump_constant([NotNull] Jump_constantContext context)
        {
            Script.AppendInstruction(new JumpConstant(context.label_name().GetText()));
            base.EnterJump_constant(context);
        }

        public override void EnterCall_constant([NotNull] Call_constantContext context)
        {
            Script.AppendInstruction(new CallConstant(context.label_name().GetText()));
            base.EnterCall_constant(context);
        }

        public override void EnterLabel_constant([NotNull] Label_constantContext context)
        {
            Script.InsertLabel(context.label_name().GetText());
            base.EnterLabel_constant(context);
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
            base.EnterSay(context);
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
            base.EnterMenu(context);
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
    }
}
