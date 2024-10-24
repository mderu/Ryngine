using Ryngine.Execution;

namespace Ryngine.Instructions
{
    public record Line
    {
        public required Instruction Instruction { get; init; }
        public required ProgramCounter ProgramCounter { get; init; }
    }
}
