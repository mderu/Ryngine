namespace AntlrRenpy.Program;

public class Block(List<IInstruction> instructions) : IPositional
{
    public List<IInstruction> Instructions { get; } = instructions;

    public IInstruction First => Instructions[0];

    public IInstruction Last => Instructions[^1];
}
