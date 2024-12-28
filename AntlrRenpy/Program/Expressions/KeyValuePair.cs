using RynVM.Instructions;
using RynVM.Instructions.Expressions;
using RynVM.Script;

namespace AntlrRenpy.Program.Expressions;

public record class KeyValuePair(IExpression Key, IExpression Value) : IAtomic
{
    IAtomic IExpression.EvaluateValue(Store<string, IAtomic> store)
    {
        // Like other Python expressions, the left is evaluated first:
        //
        //     {(a:='a'): (a:='b')} and a
        //     'b'
        //
        IAtomic keyAtomic = Key.EvaluateValue(store);
        IAtomic valueAtomic = Value.EvaluateValue(store);

        return new KeyValuePair(keyAtomic, valueAtomic);
    }
}
