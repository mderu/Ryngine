using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Instructions
{
    public record class Define(IExpression Lhs, IExpression Rhs) : IInstruction
    {
    }
}
