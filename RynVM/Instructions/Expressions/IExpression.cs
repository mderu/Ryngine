namespace RynVM.Instructions.Expressions;

public interface IExpression
{
    // TODO:
    //IExpression EvaluateAddress();
    IAtomic EvaluateValue();
}
