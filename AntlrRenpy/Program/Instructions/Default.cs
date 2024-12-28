using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Instructions;

public record class Default(IExpression Lhs, IExpression Rhs) : IInstruction
{
}
