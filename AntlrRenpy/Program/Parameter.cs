using AntlrRenpy.Program.Expressions;

namespace AntlrRenpy.Program
{
    public class Parameter(string name, IExpression? defaultValue = null)
    {
        public string Name { get; } = name;
        public IExpression? DefaultValue { get; } = defaultValue;
    }
}
