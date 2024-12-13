namespace AntlrRenpy.Program.Expressions
{
    public record class DictDefinition(List<IExpression> DictEntries) : IExpression
    {
    }
}
