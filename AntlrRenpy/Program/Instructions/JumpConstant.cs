namespace AntlrRenpy.Program.Instructions
{
    public class JumpConstant(string jumpToLabel) : IInstruction
    {
        public string label = jumpToLabel;
    }
}
