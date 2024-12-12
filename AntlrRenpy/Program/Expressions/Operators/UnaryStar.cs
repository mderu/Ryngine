namespace AntlrRenpy.Program.Expressions.Operators
{
    /// <summary>
    /// Expands the elements of an iterable into the parent iterable.
    /// </summary>
    public class UnaryStar(IExpression innerExpression) : IExpression
    {
        public IExpression InnerExpression { get; } = innerExpression;
    }
}
