namespace AntlrRenpy.Program.Expressions
{
    public record struct AssignmentExpression(string Name, IExpression ValueExpression) : IExpression
    {
    }
}
