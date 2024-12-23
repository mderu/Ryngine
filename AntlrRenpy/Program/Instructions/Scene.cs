using AntlrRenpy.Program.Clauses;
using AntlrRenpy.Program.Expressions;

namespace AntlrRenpy.Program.Instructions
{
    public record class Scene(IExpression Displayable, Transition? Transition) : IInstruction
    {
    }
}
