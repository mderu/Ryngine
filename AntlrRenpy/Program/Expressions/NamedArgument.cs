namespace AntlrRenpy.Program.Expressions
{
    public record class NamedArgument(string Name, IExpression Expression) : IExpression
    {
    }
}
