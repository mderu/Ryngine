
namespace AntlrRenpy.Program.Instructions
{
    public class Say(string text) : IInstruction
    {
        // TODO: Speaker should be an expression.
        public string Speaker { get; init; } = "";

        public string Text { get; } = text;

        // TODO: Should be an expression.
        public string WithStatement { get; init; } = "";

        // TODO: Keys should be expressions.
        public Dictionary<string, string> SayArguments { get; init; } = new();
    }
}
