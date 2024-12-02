namespace AntlrRenpy.Program.Expressions.Operators
{
    public class MemberAccess(IExpression baseExpression, string memberName) : IExpression
    {
        public IExpression BaseExpression { get; } = baseExpression;
        public string MemberName { get; } = memberName;
    }
}
