namespace AntlrRenpy.Program.Instructions;

// Sometimes, we need to leave space for an instruction to be filled in later.
public class Placeholder<T>() : IInstruction where T : IInstruction {}
