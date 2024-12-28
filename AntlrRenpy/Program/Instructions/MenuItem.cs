using AntlrRenpy.Program.Expressions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Instructions;

// https://www.renpy.org/doc/html/menus.html#menu-set
public record class MenuItem(
    string Caption,
    Block Block,
    Arguments? Arguments = null,
    IExpression? Conditional = null)
{
}
