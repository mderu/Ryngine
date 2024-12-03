namespace AntlrRenpy.Program.Expressions.Operators
{
    public class SubscriptAccess(IExpression baseExpression, IExpression sliceExpression) : IExpression
    {
        public IExpression BaseExpression { get; } = baseExpression;
        public IExpression SliceExpression { get; } = sliceExpression;
    }
}
