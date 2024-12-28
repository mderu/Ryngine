namespace Ryngine.DataStructures;

public interface IDict<TKey, TValue>
{
    public TValue this[TKey key] { get; set; }
    public bool ContainsKey(TKey key);
    public void Add(TKey key, TValue value);
}
