using RynVM.Instructions.Expressions;

namespace RynVM.Instructions.Statements;

public record class SetValue(IExpression Lhs, IExpression Rhs) : IInstruction
{
}
