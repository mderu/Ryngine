using AntlrRenpy.Program.Expressions;

namespace AntlrRenpy.Program.Instructions
{
    public class Assignment(IExpression lhs, IExpression rhs) : IInstruction
    {
        // LHS = left-hand side.
        public IExpression Lhs { get; } = lhs;

        // RHS = right-hand side.
        public IExpression Rhs { get; } = rhs;
    }
}
