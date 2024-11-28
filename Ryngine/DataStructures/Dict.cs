using System.Collections.Generic;

namespace Ryngine.DataStructures
{
    public class Dict<TKey, TValue>
        : Dictionary<TKey, TValue>, IDict<TKey, TValue>
            where TKey : notnull
            where TValue : notnull
    {
    }
}
