namespace AntlrRenpy.Program.Expressions.Operators
{
    public record class Call(IExpression Callee, IExpression Arguments) : IExpression
    {
    }
}
