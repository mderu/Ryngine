namespace AntlrRenpy.Program
{
    public class Label(string name, Parameters parameters, int instructionIndex)
    {
        public string Name { get; } = name;
        public Parameters Parameters { get; } = parameters;
        public int InstructionIndex { get; } = instructionIndex;
    }
}
