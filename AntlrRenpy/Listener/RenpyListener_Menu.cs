using AntlrRenpy.Program.Instructions;
using System.Diagnostics.CodeAnalysis;
using static RenpyParser;

namespace AntlrRenpy.Listener
{
    public partial class RenpyListener : RenpyParserBaseListener
    {
        private readonly Stack<Menu.Builder> menuBuilderStack = [];
        private readonly Stack<MenuItem.Builder> menuItemBuilderStack = [];

        public override void ExitMenu([NotNull] MenuContext context)
        {
            // Handle the label portion of the menu.
            string labelName = context.label_name()?.GetText() ?? "";
            // `menu` takes in arguments, not parameters. These arguments seem to be specific
            // See https://www.renpy.org/doc/html/menus.html#menu-arguments.
            InsertLabel(labelName, parametersContext: null);

            // Update the menu placeholder.
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
