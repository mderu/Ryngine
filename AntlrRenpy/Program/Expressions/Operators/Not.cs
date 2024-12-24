namespace AntlrRenpy.Program.Expressions.Operators
{
    /// <summary>
    /// The `not expr` expression.
    /// </summary>
    /// <param name="InvertedExpression">The expression to invert.</param>
    public record class Not(IExpression InvertedExpression) : IExpression
    {
    }
}
