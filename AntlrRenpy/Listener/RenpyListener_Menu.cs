using AntlrRenpy.Program;
using AntlrRenpy.Program.Expressions;
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
            blockStack.Push(new([]));
            menuItemsStack.Push([]);
        }

        public override void ExitMenu([NotNull] MenuContext context)
        {
            IExpression? menuSet = context.SET() is not null
                ? expressionStack.Pop()
                : null;
            
            Block sayBlock = blockStack.Pop();
            Menu menu = new(menuItemsStack.Pop(), sayBlock, menuSet);

            if (context.label_name() is Label_nameContext labelContext)
            {
                // `menu` takes in arguments, not parameters. These arguments seem to be specific
                // See https://www.renpy.org/doc/html/menus.html#menu-arguments.
                string labelName = labelContext.GetText();
                InsertLabel(labelName, menu, parametersContext: null, jumpToAfterInstruction: false);
            }

            AppendInstruction(menu);
        }

        public override void EnterMenu_item([NotNull] Menu_itemContext context)
        {
            blockStack.Push(new([]));
        }

        public override void ExitMenu_item([NotNull] Menu_itemContext context)
        {
            string caption = StringParser.Parse(context.STRING().GetText());
            Block innerBlock = blockStack.Pop();

            IExpression? conditional = context.IF() is not null
                ? expressionStack.Pop()
                : null;

            Arguments? arguments = context.arguments() is not null
                ? (Arguments)expressionStack.Pop()
                : null;

            MenuItem menuItem = new(caption, innerBlock, arguments, conditional);
            menuItemsStack.Peek().Add(menuItem);
        }
    }
}
