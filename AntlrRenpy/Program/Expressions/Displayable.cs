using RynVM.Instructions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Expressions
{
    public record class Displayable(string Name, IEnumerable<string> Properties) : IAtomic
    {
        IAtomic IExpression.EvaluateValue()
        {
            return this;
        }
    }
}
