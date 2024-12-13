namespace AntlrRenpy.Program.Expressions
{
    public record class ListDefinition(IEnumerable<IExpression> InnerExpressions) : IExpression
    {
    }
}
