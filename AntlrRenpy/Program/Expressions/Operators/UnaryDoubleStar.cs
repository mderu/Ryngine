namespace AntlrRenpy.Program.Expressions.Operators
{
    /// <summary>
    /// Expands the <see cref="InnerExpression"/>'s dictionary elements into the parent's kwargs.
    /// </summary>
    public class UnaryDoubleStar(IExpression innerExpression) : IExpression
    {
        public IExpression InnerExpression { get; } = innerExpression;
    }
}
