using AntlrRenpy.Program.Expressions;

namespace AntlrRenpy.Program.Instructions
{
    public class Assignment(IExpression rhs, IExpression lhs) : IInstruction
    {
        // RHS = right-hand side.
        public IExpression Rhs { get; } = rhs;

        // LHS = left-hand side.
        public IExpression Lhs { get; } = lhs;
    }
}
