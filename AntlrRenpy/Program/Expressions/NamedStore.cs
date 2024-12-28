using RynVM.Instructions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Expressions;

public record class NamedStore(string StoreName) : IExpression
{
    public IAtomic EvaluateValue()
    {
        throw new NotImplementedException("No idea how to implement this yet.");
    }
}
