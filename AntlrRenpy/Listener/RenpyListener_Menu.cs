using AntlrRenpy.Program;
using AntlrRenpy.Program.Instructions;
using System.Diagnostics.CodeAnalysis;
using static RenpyParser;

namespace AntlrRenpy.Listener
{
    public partial class RenpyListener : RenpyParserBaseListener
    {
        private readonly Stack<List<MenuItem>> menuItemsStack = [];

        public override void EnterMenu([NotNull] MenuContext context)
        {
            List<MenuItem> menuItems = [];
            Block sayBlock = new([]);

            // Consider supporting menuset: https://www.renpy.org/doc/html/menus.html#menu-set
            // And with expression
            Menu menu = new(menuItems, sayBlock);

            AppendInstruction(menu);

            if (context.label_name() is Label_nameContext labelContext)
            {
                // `menu` takes in arguments, not parameters. These arguments seem to be specific
                // See https://www.renpy.org/doc/html/menus.html#menu-arguments.
                string labelName = labelContext.GetText();
                InsertLabel(labelName, menu, parametersContext: null, jumpToAfterInstruction: false);
            }

            blockStack.Push(sayBlock);
            menuItemsStack.Push(menuItems);
        }

        public override void ExitMenu([NotNull] MenuContext context)
        {
            menuItemsStack.Pop();
            blockStack.Pop();
        }

        public override void EnterMenu_item([NotNull] Menu_itemContext context)
        {
            string caption = StringParser.Parse(context.STRING().GetText());
            Block innerBlock = new([]);
            MenuItem menuItem = new(caption, innerBlock);

            blockStack.Push(innerBlock);
            menuItemsStack.Peek().Add(menuItem);
        }

        public override void ExitMenu_item([NotNull] Menu_itemContext context)
        {
            blockStack.Pop();
        }
    }
}
