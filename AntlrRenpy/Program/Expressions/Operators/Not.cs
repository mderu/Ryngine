using RynVM.Instructions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Expressions.Operators;

/// <summary>
/// The `not expr` expression.
/// </summary>
/// <param name="ExpressionToInvert">The expression to invert.</param>
public record class Not(IExpression ExpressionToInvert) : IExpression
{
    IAtomic IExpression.EvaluateValue()
    {
        // In Python, if Lhs returns falsey, it returns lhs. Otherwise, it returns Rhs.
        IAtomic iAtomic = ExpressionToInvert.EvaluateValue();
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
