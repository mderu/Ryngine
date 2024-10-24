using System.Runtime.InteropServices;

namespace Ryngine
{
    public class RynClient
    {
        public string GetCurrentState() => "";
        public int GetCurrentId() => 0;
        public string[] GetDeltasToHead() => new string[0];

        public int ApplyDelta(string delta) => 0;
        public int RequestUndo(int currentId) => 0;

        [UnmanagedCallersOnly(EntryPoint = "Add")]
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
