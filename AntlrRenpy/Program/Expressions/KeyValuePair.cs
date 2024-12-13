namespace AntlrRenpy.Program.Expressions
{
    public record class KeyValuePair(IExpression Key, IExpression Value) : IExpression
    {
    }
}
