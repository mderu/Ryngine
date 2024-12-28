using RynVM.Script;

namespace RynVM.Instructions.Expressions;

public interface IExpression
{
    // TODO:
    //IExpression EvaluateAddress();
    IAtomic EvaluateValue(Store<string, IAtomic> store);
}
