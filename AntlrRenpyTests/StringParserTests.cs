using Xunit;

namespace AntlrRenpy.Test;

public class StringParserTests
{
    [Fact]
    public void Parse_MultipleWhitespace_BecomesSingleWhitespace()
    {
        string result = StringParser.Parse("\"a  b\"");
        Xunit.Assert.Equal("a b", result);
    }

    [Fact]
    public void Parse_MultipleWhitespace_DoubleNewlinesAreRespected()
    {
        string result = StringParser.Parse("\"a\n\nb\"");
        Xunit.Assert.Equal("a\n\nb", result);
    }

    [Fact]
    public void Parse_MultipleWhitespace_EscapedSpacesAreRespected()
    {
        string result = StringParser.Parse("\"a  \\   b\"");
        Xunit.Assert.Equal("a   b", result);
    }
}
