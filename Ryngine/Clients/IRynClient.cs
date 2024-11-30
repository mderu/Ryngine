namespace Ryngine.Clients
{
    public interface IRynClient
    {
        /// <summary>
        /// Returns the memory state of the current run.
        /// </summary>
        string GetState();

        /// <summary>
        /// Loads the memory state from the associated <paramref name="saveName"/>.
        /// </summary>
        void LoadState(string saveName);

        /// <summary>
        /// Saves the current memory state to a save named <paramref name="saveName"/>.
        /// </summary>
        void SaveState(string saveName);

        /// <summary>
        /// Applies the given <paramref name="delta"/> to the current state.
        /// </summary>
        /// <returns>The memory state after the delta has been applied.</returns>
        string ApplyDelta(string delta);
        /// <summary>
        /// Like <see cref="ApplyDelta(string)"/>, but does not return the state.
        /// </summary>
        void PostDelta(string delta);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string RequestUndo();

        /// <summary>
        /// Loads the underlying Multiverse from the given <paramref name="path"/>.
        /// </summary>
        void LoadMultiverse(string path);

        /// <summary>
        /// Saves the underlying Multiverse using the given <paramref name="path"/>.
        /// </summary>
        void SaveMultiverse(string path);
    }
}
