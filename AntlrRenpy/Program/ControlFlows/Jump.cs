using AntlrRenpy.Program.Expressions;

namespace AntlrRenpy.Program.ControlFlows
{
    public class Jump(IExpression jumpExpression) : IInstruction
    {
        public IExpression Label { get; } = jumpExpression;
    }
}
