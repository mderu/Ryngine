using RynVM.Instructions;
using RynVM.Instructions.Expressions;
using RynVM.Script;

namespace AntlrRenpy.Program.Expressions.Operators;

/// <summary>
/// The `not expr` expression.
/// </summary>
/// <param name="ExpressionToInvert">The expression to invert.</param>
public record class Not(IExpression ExpressionToInvert) : IExpression
{
    IAtomic IExpression.EvaluateValue(Store<string, IAtomic> store)
    {
        // In Python, if Lhs returns falsey, it returns lhs. Otherwise, it returns Rhs.
        IAtomic iAtomic = ExpressionToInvert.EvaluateValue(store);
        if (iAtomic is Atomic lhsAtomic)
        {
            return new Atomic<bool>(!lhsAtomic.IsTruthy());
        }
        else
        {
            throw new InvalidOperationException($"Unable to determine IsTruthy for {iAtomic.GetType()}.");
        }
    }
}
