namespace AntlrRenpy.Program.Expressions.Operators
{
    public record class Or(IExpression Lhs, IExpression Rhs) : IExpression
    {
    }
}
