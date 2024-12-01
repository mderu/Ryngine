using System.Collections.Generic;

namespace Ryngine.Utils
{
    public static class LinqExtensions
    {
        /// <summary>
        /// Like Python's enumerate() function.
        /// </summary>
        public static IEnumerable<(int, T)> Enumerate<T>(this IEnumerable<T> sequence)
        {
            var enumerator = sequence.GetEnumerator();

            int index = 0;
            while(enumerator.MoveNext())
            {
                yield return (index++, enumerator.Current);
            }
        }
    }
}
