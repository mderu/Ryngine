using AntlrRenpy.Program.Expressions;

namespace AntlrRenpy.Program.ControlFlows
{
    public record class If(Block IfBlock, IExpression Condition, Else? ElseStatement) : IInstruction
    {

    }
}
