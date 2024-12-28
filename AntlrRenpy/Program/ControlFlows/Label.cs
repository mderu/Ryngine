namespace AntlrRenpy.Program.ControlFlows;

/// <param name="Name">The name of the label.</param>
/// <param name="Parameters">The set of parameters the label takes in.</param>
/// <param name="Positional">The script element to point to.</param>
/// <param name="JumpToEnd">
/// If true, the label jumps to the end of the instruction/block/etc.
/// Otherwise, starts at the beginning of the positional.
/// </param>
public record class Label(string Name, Parameters Parameters, IPositional Positional, bool JumpToEnd = false)
{

}
