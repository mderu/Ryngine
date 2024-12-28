using RynVM.Instructions;
using RynVM.Instructions.Expressions;
using RynVM.Script;

namespace AntlrRenpy.Program.Expressions;

public record class Displayable(string Name, IEnumerable<string> Properties) : IAtomic
{
    IAtomic IExpression.EvaluateValue(Store<string, IAtomic> store)
    {
        return this;
    }
}
