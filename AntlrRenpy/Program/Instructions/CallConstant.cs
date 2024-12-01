namespace AntlrRenpy.Program.Instructions
{
    public class CallConstant(string jumpToLabel) : IInstruction
    {
        public string label = jumpToLabel;
    }
}
