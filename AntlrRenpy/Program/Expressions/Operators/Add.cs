using RynVM.Instructions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Expressions.Operators
{
    public record class Add(IExpression Lhs, IExpression Rhs) : IExpression
    {
        IAtomic IExpression.EvaluateValue()
        {
            IAtomic evaluatedA = Lhs.EvaluateValue();

            if (Lhs is not Atomic atomicA)
            {
                throw new Exception($"Unable to add with operand {evaluatedA.GetType()} (evaluated from {Lhs.GetType()}).");
            }

            IAtomic evaluatedB = Rhs.EvaluateValue();

            if (Rhs is not Atomic atomicB)
            {
                throw new Exception($"Unable to add with operand {evaluatedB.GetType()} (evaluated from {Rhs.GetType()}).");
            }

            return atomicA.Add(atomicB);
        }
    }
}
 