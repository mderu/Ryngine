namespace AntlrRenpy.Program.Expressions
{
    public class NamedStore(string storeName) : IExpression
    {
        public string StoreName { get; } = storeName;
    }
}
