namespace RynVM.Instructions.Statements;

/// <summary>
/// The command to commit all above memory changes into a single delta.
/// </summary>
public record struct Commit : IInstruction
{
}
