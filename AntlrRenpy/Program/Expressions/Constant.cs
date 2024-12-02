namespace AntlrRenpy.Program.Expressions
{
    public class Constant<T>(T value) : IExpression
    {
        public T Value { get; } = value; 
    }
}
