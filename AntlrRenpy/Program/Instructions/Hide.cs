using AntlrRenpy.Program.Clauses;
using AntlrRenpy.Program.Expressions;

namespace AntlrRenpy.Program.Instructions
{
    public record class Hide(IExpression Displayable, Transition? Transition) : IInstruction
    {
    }
}
