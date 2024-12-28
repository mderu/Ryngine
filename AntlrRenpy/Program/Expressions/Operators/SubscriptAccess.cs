using RynVM.Instructions;
using RynVM.Instructions.Expressions;
using RynVM.Script;

namespace AntlrRenpy.Program.Expressions.Operators;

public record class SubscriptAccess(IExpression BaseExpression, IExpression SliceExpression) : IExpression
{
    IAtomic IExpression.EvaluateValue(Store<string, IAtomic> store)
    {
        // The subscript operator is evaluated second in Python:
        //
        //     >>> (a:="first")[a:=0] and a
        //     0
        //
        IAtomic lhsAtomic = BaseExpression.EvaluateValue(store);
        IAtomic sliceAtomic = SliceExpression.EvaluateValue(store);
        if (lhsAtomic is Atomic<string> lhsString)
        {
            if (sliceAtomic is AtomicNumber sliceNumber && sliceNumber.Type == AtomicType.Int)
            {
                if (sliceNumber.Type == AtomicType.Float)
                {
                    
                }
                int index = int.Parse(sliceNumber.Value);

                if (!(-lhsString.Value.Length <= index && index < lhsString.Value.Length))
                {
                    throw new InvalidOperationException("IndexError: string index out of range");
                }
                
                if (index < 0)
                {
                    return new Atomic<string>(lhsString.Value[lhsString.Value.Length + index].ToString());
                }
                else
                {
                    return new Atomic<string>(lhsString.Value[index].ToString());
                }
            }
            else
            {
                throw new InvalidOperationException(
                    $"TypeError: string indices must be integers, not '{sliceAtomic.GetType()}'");
            }
        }

        throw new NotImplementedException("Will implement when list is fleshed out.");
    }
}
