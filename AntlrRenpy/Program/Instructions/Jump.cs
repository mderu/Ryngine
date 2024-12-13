using AntlrRenpy.Program.Expressions;

namespace AntlrRenpy.Program.Instructions
{
    public class Jump(IExpression jumpExpression) : IInstruction
    {
        public IExpression Label { get; } = jumpExpression;
    }
}
