using AntlrRenpy.Listener;
using AntlrRenpy.Program.Expressions;
using AntlrRenpy.Program.Instructions;
using AntlrRenpyTests;
using RynVM.Instructions;
using RynVM.Script;
using Xunit;
using Assert = Xunit.Assert;

namespace AntlrRenpy.Test;

public class ExpressionEvaluationTests
{
    [Fact]
    public void Test008__sum()
    {
        (RenpyListener renpyListener, ParserErrorListener errorListener) =
            ParseTreeTests.Parse("test008__sum.rpy");

        Assert.Empty(errorListener.Errors);

        var labels = renpyListener.Script.Labels;
        Assert.Empty(labels);

        var instructions = renpyListener.Script.Instructions;

        Store<string, IAtomic> store = new()
        {
            ["a"] = new AtomicNumber("1"),
            ["b"] = new AtomicNumber("2"),
        };

        Assert.Collection(instructions,
            (item) => {},
            (item) => {},
            (item) => {},
            (item) =>
            {
                ParseTreeTests.AssertType(item, out Assignment assignment);
                IAtomic result = assignment.Rhs.EvaluateValue(store);

                Assert.Equal(new AtomicNumber("5"), result);
            }
        );
    }
}
