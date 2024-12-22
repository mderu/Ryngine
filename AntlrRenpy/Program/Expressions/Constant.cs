namespace AntlrRenpy.Program.Expressions
{
    public record class Constant<T>(T value) : IExpression
    {
        public T Value { get; } = value; 
    }
}
