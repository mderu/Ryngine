namespace AntlrRenpy.Program.Expressions.Operators
{
    public class Add(IExpression a, IExpression b) : IExpression
    {
        public IExpression A { get; } = a;
        public IExpression B { get; } = b;
    }
}
