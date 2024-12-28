using System;
using System.Runtime.InteropServices;

namespace Ryngine.Clients
{
    public class NativeRynClient
    {
        public static NativeRynClient Instance { get; } = new NativeRynClient();

        [UnmanagedCallersOnly(EntryPoint = "GetSnapshot")]
        public static IntPtr GetSnapshot(IntPtr saveName) => 0;

        [UnmanagedCallersOnly(EntryPoint = "ApplyDelta")]
        public static IntPtr ApplyDelta(IntPtr saveName, IntPtr delta) => 0;

        [UnmanagedCallersOnly(EntryPoint = "PostDelta")]
        public static void PostDelta(IntPtr saveName, IntPtr delta) { }

        [UnmanagedCallersOnly(EntryPoint = "RequestUndo")]
        public static IntPtr RequestUndo(IntPtr saveName) => 0;

        //============================================================================
        //============================================================================
        //============================================================================
        //===============================Test Functions===============================
        //============================================================================
        //============================================================================
        //============================================================================

        [UnmanagedCallersOnly(EntryPoint = "Add")]
        public static int Add(int a, int b)
        {
            return a + b;
        }

        // Expose the method for unmanaged code
        [UnmanagedCallersOnly(EntryPoint = "Reverse")]
        public static IntPtr Reverse(IntPtr input)
        {
            // Convert the unmanaged string to a managed string
            string managedInput = Marshal.PtrToStringAnsi(input) ?? string.Empty;

            // Reverse the string
            char[] charArray = managedInput.ToCharArray();
            Array.Reverse(charArray);
            string reversed = new string(charArray);

            // Allocate memory for the reversed string in unmanaged space and return its pointer
            IntPtr result = Marshal.StringToHGlobalAnsi(reversed);
            return result;
        }
    }
}
