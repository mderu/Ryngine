using AntlrRenpy.Program.Expressions;

namespace AntlrRenpy.Program.Instructions
{
    public record class ExpressionAsInstruction(IExpression Expression) : IInstruction
    {
    }
}
