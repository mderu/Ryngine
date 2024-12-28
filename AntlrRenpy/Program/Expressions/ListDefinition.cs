using RynVM.Instructions;
using RynVM.Instructions.Expressions;
using RynVM.Script;

namespace AntlrRenpy.Program.Expressions;

public record class ListDefinition(IEnumerable<IExpression> InnerExpressions) : IExpression
{
    IAtomic IExpression.EvaluateValue(Store<string, IAtomic> store)
    {
        throw new NotImplementedException();
    }
}
