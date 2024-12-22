using AntlrRenpy.Program.ControlFlows;
using AntlrRenpy.Program.Instructions;

namespace AntlrRenpy.Program
{
    public class Script
    {
        private readonly Dictionary<string, Label> labels = [];
        private readonly List<IInstruction> instructions = [];
        private readonly Dictionary<object, int> placeholderIndexes = [];

        public IReadOnlyDictionary<string, Label> Labels => labels.AsReadOnly();
        public IReadOnlyList<IInstruction> Instructions => instructions.AsReadOnly();

        public void AppendInstruction(IInstruction instruction)
        {
            instructions.Add(instruction);
        }


        public int NextInstructionIndex => instructions.Count;

        public IInstruction FirstInstruction => Instructions[0];
        public IInstruction LastInstruction => Instructions[^1];

        public void InsertLabel(Label label)
        {
            labels[label.Name] = label;
        }

        public void ReplacePlaceholder<T>(Placeholder<T> placeholder, T replacement)
            where T : IInstruction
        {
            if (placeholderIndexes.TryGetValue(placeholder, out int index))
            {
                instructions[index] = replacement;
            }
            else
            {
                throw new InvalidOperationException(
                    $"Placeholder<{replacement.GetType()}> was not found in the script.");
            }
        }
    }
}
