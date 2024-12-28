using RynVM.Instructions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Expressions.Operators;

public record class Or(IExpression Lhs, IExpression Rhs) : IExpression
{
    IAtomic IExpression.EvaluateValue()
    {
        // In Python, if lhs returns truthy, that is immediately returned. Otherwise, rhs is evaluated and returned.
        var lhsIAtomic = Lhs.EvaluateValue();
        if (lhsIAtomic is Atomic lhsAtomic)
        {
            return lhsAtomic.IsTruthy()
                ? lhsIAtomic
                : Rhs.EvaluateValue();
        }
        else
        {
            throw new InvalidOperationException($"Unable to determine IsTruthy for {lhsIAtomic.GetType()}.");
        }
    }
}
