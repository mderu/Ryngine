using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Instructions;

public record class Menu(List<MenuItem> MenuItems, Block SayBlock, IExpression? MenuSet = null)
    : IInstruction
{
}
