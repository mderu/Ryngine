using RynVM.Instructions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Expressions;

public record class KeyValuePair(IExpression Key, IExpression Value) : IAtomic
{
    IAtomic IExpression.EvaluateValue()
    {
        // Like other Python expressions, the left is evaluated first:
        //
        //     {(a:='a'): (a:='b')} and a
        //     'b'
        //
        IAtomic keyAtomic = Key.EvaluateValue();
        IAtomic valueAtomic = Value.EvaluateValue();

        return new KeyValuePair(keyAtomic, valueAtomic);
    }
}
