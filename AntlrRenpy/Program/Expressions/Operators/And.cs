namespace AntlrRenpy.Program.Expressions.Operators
{
    public record class And(IExpression Lhs, IExpression Rhs) : IExpression
    {
    }
}
