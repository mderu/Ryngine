using RynVM.Instructions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Expressions;

public record class ListDefinition(IEnumerable<IExpression> InnerExpressions) : IExpression
{
    IAtomic IExpression.EvaluateValue()
    {
        throw new NotImplementedException();
    }
}
