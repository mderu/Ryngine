using RynVM.Instructions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Expressions.Operators;

public record class MemberAccess(IExpression BaseExpression, string MemberName) : IExpression
{
    IAtomic IExpression.EvaluateValue()
    {
        throw new NotImplementedException("Will implement when dict is fleshed out.");
    }
}
