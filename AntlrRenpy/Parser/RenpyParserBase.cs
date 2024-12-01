using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

public abstract class RenpyParserBase : Parser
{
    protected RenpyParserBase(ITokenStream input) : base(input)
    {
    }

    protected RenpyParserBase(ITokenStream input, TextWriter output, TextWriter errorOutput)
        : base(input, output, errorOutput)
    {
    }

    // https://docs.python.org/3/reference/lexical_analysis.html#soft-keywords
    public bool isEqualToCurrentTokenText(string tokenText)
    {
        return this.CurrentToken.Text == tokenText;
    }

    public bool isNotEqualToCurrentTokenText(string tokenText)
    {
        return !isEqualToCurrentTokenText(tokenText); // for compatibility with the Python 'not' logical operator
    }
}