namespace AntlrRenpy.Program.Expressions.Operators
{
    public class Call(IExpression callee, IExpression expression) : IExpression
    {
        public IExpression Callee { get; } = callee;
        public IExpression Arguments { get; } = expression;
    }
}
