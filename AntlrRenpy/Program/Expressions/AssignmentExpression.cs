using RynVM.Instructions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Expressions;

public record struct AssignmentExpression(string Name, IExpression ValueExpression) : IExpression
{
    IAtomic IExpression.EvaluateValue()
    {
        throw new NotImplementedException("No idea how to accomplish this.");
    }
}
