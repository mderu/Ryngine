using AntlrRenpy.Program.Expressions;

namespace AntlrRenpy.Program.Instructions
{
    // Pushes a new variable frame onto the stack, and jumps to a label.
    // Effectively a "call" in Ren'Py, but renamed here to avoid confusing
    // it with function call expressions.
    public class PushFrame(string labelName, IExpression expression) : IInstruction
    {
        public string LabelName { get; } = labelName;
        public IExpression Arguments { get; } = expression;
    }
}
