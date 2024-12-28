using RynVM.Instructions;
using RynVM.Instructions.Expressions;
using RynVM.Script;

namespace AntlrRenpy.Program.Expressions;

public record class NamedArgument(string Name, IExpression Expression) : IExpression
{
    IAtomic IExpression.EvaluateValue(Store<string, IAtomic> store)
    {
        throw new NotImplementedException("No idea how to do this yet.");
    }
}
