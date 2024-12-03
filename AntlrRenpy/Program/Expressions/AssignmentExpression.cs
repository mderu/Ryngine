namespace AntlrRenpy.Program.Expressions
{
    public class AssignmentExpression(string name, IExpression valueExpression) : IExpression
    {
        public string Name { get; } = name;
        public IExpression ValueExpression { get; } = valueExpression;
    }
}
