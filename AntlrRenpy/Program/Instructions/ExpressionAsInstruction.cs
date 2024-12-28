using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Instructions;

public record class ExpressionAsInstruction(IExpression Expression) : IInstruction
{
}
