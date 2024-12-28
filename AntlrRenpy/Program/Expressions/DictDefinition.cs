using RynVM.Instructions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Expressions;

public record class DictDefinition(List<IExpression> DictEntries) : IExpression
{
    IAtomic IExpression.EvaluateValue()
    {
        throw new NotImplementedException();
    }
}
