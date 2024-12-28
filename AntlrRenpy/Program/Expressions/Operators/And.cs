using RynVM.Instructions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Expressions.Operators;

public record class And(IExpression Lhs, IExpression Rhs) : IExpression
{
    IAtomic IExpression.EvaluateValue()
    {
        // In Python, if Lhs returns falsey, it returns lhs. Otherwise, it returns Rhs.
        IAtomic lhsIAtomic = Lhs.EvaluateValue();
        if (lhsIAtomic is Atomic lhsAtomic)
        {
            return lhsAtomic.IsTruthy()
                ? Rhs.EvaluateValue()
                : lhsIAtomic;
        }
        else
        {
            throw new InvalidOperationException($"Unable to determine IsTruthy for {lhsIAtomic.GetType()}.");
        }
    }
}
