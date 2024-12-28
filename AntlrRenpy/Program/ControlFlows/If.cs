using AntlrRenpy.Program.Expressions;
using RynVM.Instructions.Expressions;


namespace AntlrRenpy.Program.ControlFlows;

public record class If(Block IfBlock, IExpression Condition, Else? ElseStatement) : IInstruction
{

}
