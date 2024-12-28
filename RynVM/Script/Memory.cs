using RynVM.Instructions;

namespace RynVM.Script
{
    public class Memory()
    {
        public Store<string, IAtomic> Addresses { get; } = new();
    }
}
