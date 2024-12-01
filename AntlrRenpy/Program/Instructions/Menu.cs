using Ryngine.Utils;

namespace AntlrRenpy.Program.Instructions
{
    public class Menu(List<MenuItem> menuItems, int? sayIndex = null)
        : IInstruction
    {
        public class Builder(int selfInstructionIndex)
        {
            private readonly List<MenuItem> menuItems = [];
            private int? sayInstructionIndex = null;

            public int SelfInstructionIndex { get; } = selfInstructionIndex;

            public void SetSayInstructionIndex(int index)
            {
                sayInstructionIndex = index;
            }

            public void AddMenuItem(MenuItem menuItem)
            {
                menuItems.Add(menuItem);
            }

            public Menu Build()
            {
                if (menuItems.Count == 0)
                {
                    throw new RequiredFieldException(nameof(AddMenuItem));
                }

                return new(menuItems, sayInstructionIndex);
            }
        }

        public List<MenuItem> MenuItems { get; } = menuItems;
        public int? SayInstructionIndex { get; set; } = sayIndex;
    }
}
