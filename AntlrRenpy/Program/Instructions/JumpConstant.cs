using AntlrRenpy.Program.Expressions;

namespace AntlrRenpy.Program.Instructions
{
    public class JumpConstant(IExpression jumpExpression) : IInstruction
    {
        public IExpression Label { get; } = jumpExpression;
    }
}
