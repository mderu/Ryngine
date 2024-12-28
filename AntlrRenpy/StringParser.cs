using System.Text;

namespace AntlrRenpy;

public static class StringParser
{
    // Not accurate yet, only handles base cases.
    public static string Parse(string inputString)
    {
        StringBuilder result = new();
        string beginningQuoteType = "\"";
        char escapeChar = '\0';
        char capturedWhitespace = '\0';
        for (int i = 0; i < inputString.Length; i++)
        {
            char curChar = inputString[i];
            if (i == 0)
            {
                if (curChar != '"' && curChar != '\'')
                {
                    throw new InvalidDataException(
                        $"Not sure how we got here, but the string started with {curChar} " +
                        $"instead of a quote character.");
                }

                if (curChar == inputString[1] && curChar == inputString[2])
                {
                    beginningQuoteType = new string(curChar, 3);
                    i += 2;
                    continue;
                }
                else
                {
                    beginningQuoteType = new string(curChar, 1);
                }
            }
            else if (i >= inputString.Length - beginningQuoteType.Length)
            {
                break;
            }
            // Pretend the carriage returns do not exist in the source string.
            // This should make it easier to parse for double newlines in monologue strings.
            // https://www.renpy.org/doc/html/dialogue.html#monologue-mode
            // Hopefully there isn't some obscure rule in Ren'Py with carriage returns.
            // Additionally, hopefully there aren't any developers that actually want/need
            // these in their strings.
            else if (curChar == '\r')
            {
                continue;
            }
            else if (curChar == 'n' && escapeChar == '\\')
            {
                result.Append('\n');
                escapeChar = '\0';
            }
            else if (curChar == '\\' && escapeChar == '\\')
            {
                result.Append('\\');
                escapeChar = '\0';
            }
            else if (curChar == ' ' && escapeChar == '\\')
            {
                result.Append(' ');
                escapeChar = '\0';
            }
            // Ren'Py script text collapses adjacent whitespace into a single space character.
            // https://www.renpy.org/doc/html/text.html#:~:text=Includes%20an%20additional%20space%20in%20a%20Ren%27Py%20string.%20By%20default%2C%20Ren%27Py%20script%20text%20collapses%20adjacent%20whitespace%20into%20a%20single%20space%20character.
            else if (curChar == ' ' || curChar == '\t')
            {
                if (escapeChar == '\\')
                {
                    result.Append(curChar);
                    escapeChar = '\0';
                    capturedWhitespace = '\0';
                }
                else if (capturedWhitespace == '\0')
                {
                    capturedWhitespace = curChar;
                }
                else
                {
                    capturedWhitespace = ' ';
                }
            }
            else if (curChar == '\\')
            {
                if (capturedWhitespace != '\0')
                {
                    result.Append(capturedWhitespace);
                    capturedWhitespace = '\0';
                }
                escapeChar = '\\';
            }
            else
            {
                if (capturedWhitespace != '\0')
                {
                    result.Append(capturedWhitespace);
                    capturedWhitespace = '\0';
                }

                result.Append(curChar);
                escapeChar = '\0';
            }
        }

        if (capturedWhitespace != '\0')
        {
            result.Append(capturedWhitespace);
        }

        return result.ToString();
    }
}
