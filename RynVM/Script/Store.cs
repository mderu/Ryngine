using Ryngine.DataStructures;

namespace RynVM.Script
{
    public class Store<TKey, TValue>() : IDict<TKey, TValue>
        where TKey : notnull
        where TValue : notnull
    {
        private readonly Stack<Dictionary<TKey, TValue>> StackFrames = new([[]]);

        public TValue this[TKey key]
        {
            get
            {
                foreach (Dictionary<TKey, TValue> frame in StackFrames)
                {
                    if (frame.TryGetValue(key, out TValue? value))
                    {
                        return value;
                    }
                }
                throw new InvalidOperationException($"NameError: name '{key.ToString()}' is not defined");
            }
            set
            {
                StackFrames.Peek()[key] = value;
            }
        }

        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key))
            {
                throw new ArgumentException($"An element with the same key {key} already exists in the DbCache.");
            }
            this[key] = value;
        }

        public bool ContainsKey(TKey key)
        {
            foreach (Dictionary<TKey, TValue> frame in StackFrames)
            {
                if (frame.ContainsKey(key))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
