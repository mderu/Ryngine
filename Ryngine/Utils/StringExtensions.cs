namespace Ryngine.Utils
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns a string with the specified prefix trimmed.
        /// </summary>
        public static string TrimPrefix(this string str, string prefix)
        {
            if (str.StartsWith(prefix))
            {
                return str[prefix.Length..];
            }

            return str;
        }
    }
}
