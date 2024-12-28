using RynVM.Instructions;
using RynVM.Instructions.Expressions;
using RynVM.Script;

namespace AntlrRenpy.Program.Expressions.Operators;

public record class Or(IExpression Lhs, IExpression Rhs) : IExpression
{
    IAtomic IExpression.EvaluateValue(Store<string, IAtomic> store)
    {
        // In Python, if lhs returns truthy, that is immediately returned. Otherwise, rhs is evaluated and returned.
        var lhsIAtomic = Lhs.EvaluateValue(store);
        if (lhsIAtomic is Atomic lhsAtomic)
        {
            return lhsAtomic.IsTruthy()
                ? lhsIAtomic
                : Rhs.EvaluateValue(store);
        }
        else
        {
            throw new InvalidOperationException($"Unable to determine IsTruthy for {lhsIAtomic.GetType()}.");
        }
    }
}
