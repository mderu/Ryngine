namespace AntlrRenpy.Program.Expressions.Operators
{
    public class Negate(IExpression expression) : IExpression
    {
        public IExpression ExpressionToNegate { get; } = expression;
    }
}
