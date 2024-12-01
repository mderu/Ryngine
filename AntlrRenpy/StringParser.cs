using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrRenpy
{
    public static class StringParser
    {
        // Not accurate yet, only handles base cases.
        //public string Parse(string inputString)
        //{
        //    StringBuilder result = new();
        //    string beginningQuoteType = 
        //    for (int i = 0; i < inputString.Length; i++)
        //    {
        //        if (i == 0)
        //        {
        //            if (inputString[i] == '"')
        //        }
        //    }

        //    string unquotedString = inputString;
        //    if (inputString.StartsWith('"'))
        //    {
        //        unquotedString = inputString
        //            // Get rid of start and stop quotes.
        //            .Trim('\'')
        //            // Unescape quote.
        //            .Replace("\\'", "'")
        //    }
        //    else
        //    {
        //        unquotedString = inputString
        //            // Get rid of start and stop quotes.
        //            .Trim('"')
        //            // Unescape quote.
        //            .Replace("\\\"", "\"")
        //    }

        //    // Ren'Py script text collapses adjacent whitespace into a single space character.
        //    // https://www.renpy.org/doc/html/text.html#:~:text=Includes%20an%20additional%20space%20in%20a%20Ren%27Py%20string.%20By%20default%2C%20Ren%27Py%20script%20text%20collapses%20adjacent%20whitespace%20into%20a%20single%20space%20character.

        //    unquotedString
        //        .Replace("\\n", "\n")
        //        .Replace("\\ ", " ")
        //        .Replace("\\\\", "\\")
        //        // TODO: The below two rules impact one another
        //        .Replace("\\%", "%")
        //        .Replace("%%", "%")
        //}
    }
}
