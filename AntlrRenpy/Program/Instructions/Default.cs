using AntlrRenpy.Program.Expressions;

namespace AntlrRenpy.Program.Instructions
{
    public record class Default(IExpression Lhs, IExpression Rhs) : IInstruction
    {
    }
}
