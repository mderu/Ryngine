using Ryngine.Utils;

namespace AntlrRenpy.Program.Instructions
{
    public class Menu(List<MenuItem> menuItems, Block sayBlock)
        : IInstruction
    {
        public List<MenuItem> MenuItems { get; } = menuItems;
        public Block SayBlock { get; set; } = sayBlock;
    }
}
