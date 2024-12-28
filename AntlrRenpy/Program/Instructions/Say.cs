
namespace AntlrRenpy.Program.Instructions;

public class Say(string text) : IInstruction
{
    // TODO: Speaker should be an expression.
    public string Speaker { get; init; } = "";

    public string Text { get; } = text;

    // TODO: Should be an expression.
    public string WithStatement { get; init; } = "";

    // TODO: Keys should be expressions.
    public Dictionary<string, string> SayArguments { get; init; } = new();

    public override bool Equals(object? obj)
    {
        return obj is Say other &&
            other.Speaker == Speaker &&
            other.Text == Text;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Speaker, Text);
    }
}
