using RynVM.Instructions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Expressions.Operators;

public record class Call(IExpression Callee, IExpression Arguments) : IExpression
{
    IAtomic IExpression.EvaluateValue()
    {
        // TODO: Call expressions are not Ren'Py Call instructions.
        // We don't have functions implemented yet, so we don't have anything to do here.
        // We will need to have some sort of call + return value stack, and this expression
        // may need to turn into multiple instructions.
        throw new NotImplementedException();
    }
}
