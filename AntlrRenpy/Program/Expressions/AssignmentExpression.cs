using RynVM.Instructions;
using RynVM.Instructions.Expressions;
using RynVM.Script;

namespace AntlrRenpy.Program.Expressions;

public record struct AssignmentExpression(string Name, IExpression ValueExpression) : IExpression
{
    IAtomic IExpression.EvaluateValue(Store<string, IAtomic> store)
    {
        throw new NotImplementedException("No idea how to accomplish this.");
    }
}
