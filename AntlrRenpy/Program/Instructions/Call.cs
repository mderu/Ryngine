using AntlrRenpy.Program.Expressions;

namespace AntlrRenpy.Program.Instructions
{
    public class Call(IExpression callee, IExpression expression) : IInstruction, IExpression
    {
        public IExpression Callee { get; } = callee;
        public IExpression Arguments { get; } = expression;
    }
}
