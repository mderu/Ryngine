namespace Ryngine.Execution
{
    public readonly struct ProgramCounter(string instructionHash)
    {
        private readonly string instructionHash = instructionHash;

        public static implicit operator string(ProgramCounter pc)
        {
            return pc.instructionHash;
        }
        public static implicit operator ProgramCounter(string d)
        {
            return new ProgramCounter(d);
        }
    }
}
