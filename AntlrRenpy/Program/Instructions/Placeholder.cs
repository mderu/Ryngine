namespace AntlrRenpy.Program.Instructions
{
    // Sometimes, we need to leave space for an instruction to be filled in later.
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Placeholder<T>(object requester)
        : IInstruction 
            where T : IInstruction
    {
        /// <summary>
        /// For additional safety, we only allow placeholders to be replaced if an object that
        /// requested it is able to come back to replace it.
        /// </summary>
        public object Requester { get; } = requester;
    }
}
