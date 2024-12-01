using Ryngine.Utils;

namespace AntlrRenpy.Program.Instructions
{
    // https://www.renpy.org/doc/html/menus.html#menu-set
    public class MenuItem(string caption, int startIndex, int endIndex)
    {
        public class Builder
        {
            private string? caption;
            private int? startIndex;
            private int? endIndex;

            public void SetCaption(string caption) => this.caption = caption;
            public void SetStartInstructionIndex(int startIndex) => this.startIndex = startIndex;
            public void SetEndInstructionIndex(int endIndex) => this.endIndex = endIndex;

            public MenuItem Build() => new(
                caption ?? throw new RequiredFieldException(nameof(SetCaption)),
                startIndex ?? throw new RequiredFieldException(nameof(SetStartInstructionIndex)),
                endIndex ?? throw new RequiredFieldException(nameof(SetEndInstructionIndex))
            );
        }

        public string Caption { get; } = caption;
        public int StartInstructionIndex { get; } = startIndex;

        /// <remarks>
        /// Not inclusive.
        /// </remarks>
        public int EndInstructionIndex { get; } = endIndex;
    }
}
