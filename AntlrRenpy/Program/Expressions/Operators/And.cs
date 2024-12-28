using RynVM.Instructions;
using RynVM.Instructions.Expressions;
using RynVM.Script;

namespace AntlrRenpy.Program.Expressions.Operators;

public record class And(IExpression Lhs, IExpression Rhs) : IExpression
{
    IAtomic IExpression.EvaluateValue(Store<string, IAtomic> store)
    {
        // In Python, if Lhs returns falsey, it returns lhs. Otherwise, it returns Rhs.
        IAtomic lhsIAtomic = Lhs.EvaluateValue(store);
        if (lhsIAtomic is Atomic lhsAtomic)
        {
            return lhsAtomic.IsTruthy()
                ? Rhs.EvaluateValue(store)
                : lhsIAtomic;
        }
        else
        {
            throw new InvalidOperationException($"Unable to determine IsTruthy for {lhsIAtomic.GetType()}.");
        }
    }
}
