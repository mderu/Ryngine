using AntlrRenpy.Program.Instructions;

namespace AntlrRenpy.Program
{
    public class Script
    {
        private readonly Dictionary<string, Label> labels = new();
        private readonly List<IInstruction> instructions = new();

        public IReadOnlyDictionary<string, Label> Labels => labels.AsReadOnly();
        public IReadOnlyList<IInstruction> Instructions => instructions.AsReadOnly();

        public void AppendInstruction(IInstruction instruction)
        {
            instructions.Add(instruction);
        }

        public int NextInstructionIndex => instructions.Count;

        public void InsertLabel(Label label)
        {
            labels[label.Name] = label;
        }

        public void ReplacePlaceholder<T>(int index, object requester, T replacement)
            where T : IInstruction
        {
            if (instructions[index] is not Placeholder<T> placeholder)
            {
                throw new InvalidOperationException(
                    $"Placeholder<{replacement.GetType()}> was not found at index {index}, " +
                    $"found an instruction of type {instructions[index].GetType()} instead.");
            }
            if (placeholder.Requester != requester)
            {
                throw new InvalidOperationException(
                    $"Placeholder reserved by <{placeholder.Requester}>, recieved {requester}");
            }
            instructions[index] = replacement;
        }
    }
}
