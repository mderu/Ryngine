namespace AntlrRenpy.Program.Expressions
{
    public record class Displayable(string Name, IEnumerable<string> Properties) : IExpression
    {
    }
}
