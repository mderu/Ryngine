using RynVM.Instructions;

namespace RynVM.Script;

public class RynScript
{
    private string[] resources;
    private Dictionary<string, IInstruction> labels;
}
