using RynVM.Instructions;
using RynVM.Instructions.Expressions;
using RynVM.Script;

namespace AntlrRenpy.Program.Expressions.Operators;

public record class Add(IExpression Lhs, IExpression Rhs) : IExpression
{
    IAtomic IExpression.EvaluateValue(Store<string, IAtomic> store)
    {
        IAtomic lhsEvaluated = Lhs.EvaluateValue(store);

        if (lhsEvaluated is not Atomic lhsAtomic)
        {
            throw new Exception($"Unable to add with operand {lhsEvaluated.GetType()} (evaluated from {Lhs.GetType()}).");
        }

        IAtomic rhsEvaluated = Rhs.EvaluateValue(store);

        if (rhsEvaluated is not Atomic rhsAtomic)
        {
            throw new Exception($"Unable to add with operand {rhsEvaluated.GetType()} (evaluated from {Rhs.GetType()}).");
        }

        return lhsAtomic.Add(rhsAtomic);
    }
}
