using RynVM.Instructions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Expressions;

public record class NamedArgument(string Name, IExpression Expression) : IExpression
{
    IAtomic IExpression.EvaluateValue()
    {
        throw new NotImplementedException("No idea how to do this yet.");
    }
}
