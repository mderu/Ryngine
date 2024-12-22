using Ryngine.Utils;

namespace AntlrRenpy.Program.Instructions
{
    // https://www.renpy.org/doc/html/menus.html#menu-set
    public class MenuItem(string caption, Block block)
    {
        public string Caption { get; } = caption;
        public Block Block { get; } = block;
    }
}
