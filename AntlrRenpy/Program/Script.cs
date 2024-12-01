namespace AntlrRenpy.Program
{
    public class Script
    {
        private readonly Dictionary<string, int> labels = new();
        private readonly List<IInstruction> instructions = new();

        public IReadOnlyDictionary<string, int> Labels => labels.AsReadOnly();
        public IReadOnlyList<IInstruction> Instructions => instructions.AsReadOnly();

        public void AppendInstruction(IInstruction instruction)
        {
            instructions.Add(instruction);
        }

        public void InsertLabel(string label)
        {
            labels[label] = instructions.Count;
        }
    }
}
