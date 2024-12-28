using AntlrRenpy.Program.Clauses;

namespace AntlrRenpy.Program.Instructions;

public record class Window(bool Show, Transition? Transistion) : IInstruction
{
}
