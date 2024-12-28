using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Instructions;

public record class With(IExpression expression) : IInstruction
{
}
