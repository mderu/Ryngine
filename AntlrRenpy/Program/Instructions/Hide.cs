using AntlrRenpy.Program.Clauses;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Instructions;

public record class Hide(IExpression Displayable, Transition? Transition) : IInstruction
{
}
