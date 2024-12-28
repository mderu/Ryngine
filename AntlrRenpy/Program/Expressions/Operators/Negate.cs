using RynVM.Instructions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Expressions.Operators;

public record class Negate(IExpression ExpressionToNegate) : IExpression
{
    IAtomic IExpression.EvaluateValue()
    {
        // In Python, if Lhs returns falsey, it returns lhs. Otherwise, it returns Rhs.
        IAtomic iAtomic = ExpressionToNegate.EvaluateValue();
        if (iAtomic is Atomic<bool> lhsBool)
        {
            return new AtomicNumber(lhsBool.Value ? "-1" : "0");
        }
        else if (iAtomic is AtomicNumber lhsNumber)
        {
            return new AtomicNumber(lhsNumber.Value.StartsWith('-') ? lhsNumber.Value[1..] : '-' + lhsNumber.Value);
        }
        else
        {
            throw new InvalidOperationException($"TypeError: bad operand type for unary -: '{iAtomic.GetType()}'");
        }
    }
}
