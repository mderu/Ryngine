namespace AntlrRenpyTests;

using Xunit;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using AntlrRenpy;
using AntlrRenpy.Program.Instructions;
using Assert = Xunit.Assert;
using Xunit.Sdk;

public class ParseTreeTests
{
    public record class ParseError
    {
        public required RecognitionException Exception { get; init; }
        public required int Line { get; init; }
        public required int Column { get; init; }
        public required string SourceName { get; init; }
        public required string Message { get; init; }
    }

    public class ParserErrorListener : BaseErrorListener
    {
        private readonly List<ParseError> errors = [];

        public IReadOnlyList<ParseError> Errors => errors.AsReadOnly();
        
        public override void SyntaxError(
            TextWriter output, IRecognizer recognizer,
            IToken offendingSymbol, int line,
            int charPositionInLine, string msg,
            RecognitionException e)
        {
            errors.Add(new ParseError {
                Exception = e,
                Line = line,
                Column = charPositionInLine,
                SourceName = recognizer.InputStream.SourceName,
                Message = msg,
            });
        }
    }

    public (RenpyListener, ParserErrorListener) Parse(string testFile)
    {
        string renpyFileName = Path.Combine(
            ".",
            "TestScripts",
            testFile
        );

        string text = File.ReadAllText(renpyFileName);

        AntlrInputStream inputStream = new(text);
        RenpyLexer speakLexer = new(inputStream);
        CommonTokenStream commonTokenStream = new(speakLexer);
        RenpyParser parser = new(commonTokenStream);

        RenpyListener renpyListener = new();
        ParserErrorListener errorListener = new();
        parser.AddErrorListener(errorListener);
        ParseTreeWalker.Default.Walk(renpyListener, parser.entire_tree());

        return (renpyListener, errorListener);
    }

    [Fact]
    public void Test000_empty_file()
    {
        (RenpyListener renpyListener, ParserErrorListener errorListener) = Parse("test000__empty_file.rpy");

        Assert.Empty(errorListener.Errors);
        Assert.Empty(renpyListener.Script.Labels);
        Assert.Empty(renpyListener.Script.Instructions);
    }

    [Fact]
    public void Test001__single_statement()
    {
        (RenpyListener renpyListener, ParserErrorListener errorListener) = Parse("test001__single_statement.rpy");

        Assert.Empty(errorListener.Errors);

        var labels = renpyListener.Script.Labels;
        Assert.Empty(labels);

        var instructions = renpyListener.Script.Instructions;
        Assert.Collection(instructions,
            (item) => Assert.Equal(typeof(Pass), item.GetType())
        );
    }

    [Fact]
    public void Test002__labels_and_jumps()
    {
        (RenpyListener renpyListener, ParserErrorListener errorListener) = Parse("test002__labels_and_jumps.rpy");

        Assert.Empty(errorListener.Errors);

        var labels = renpyListener.Script.Labels;
        Assert.Collection(labels,
            (item) => { Assert.Equal("myLabelName", item.Key); Assert.Equal(2, item.Value); },
            (item) => { Assert.Equal("otherLabel", item.Key); Assert.Equal(3, item.Value); },
            (item) => { Assert.Equal("anotherLabel", item.Key); Assert.Equal(4, item.Value); },
            (item) => { Assert.Equal("multiLabel0", item.Key); Assert.Equal(5, item.Value); },
            (item) => { Assert.Equal("multiLabel1", item.Key); Assert.Equal(5, item.Value); },
            (item) => { Assert.Equal("multiLabel2", item.Key); Assert.Equal(5, item.Value); }
        );

        var instructions = renpyListener.Script.Instructions;
        Assert.Collection(instructions,
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
            (item) => Assert.Equal(typeof(JumpConstant), item.GetType()),
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
            (item) => Assert.Equal(typeof(Pass), item.GetType())
        );
    }

    [Fact]
    public void Test003__call_and_return()
    {
        (RenpyListener renpyListener, ParserErrorListener errorListener) = Parse("test003__call_and_return.rpy");

        Assert.Empty(errorListener.Errors);

        var labels = renpyListener.Script.Labels;
        Assert.Collection(labels,
            (item) => { Assert.Equal("myLabel", item.Key); Assert.Equal(1, item.Value); },
            (item) => { Assert.Equal("skipMyLabel", item.Key); Assert.Equal(3, item.Value); }
        );

        var instructions = renpyListener.Script.Instructions;
        Assert.Collection(instructions,
            (item) => Assert.Equal(typeof(JumpConstant), item.GetType()),
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
            (item) => Assert.Equal(typeof(ReturnSimple), item.GetType()),
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
            (item) => Assert.Equal(typeof(CallConstant), item.GetType()),
            (item) => Assert.Equal(typeof(Pass), item.GetType())
        );
    }

    [Fact]
    public void Test004__say()
    {
        string renpyFileName = Path.Combine(
            ".",
            "TestScripts",
            "test003__call_and_return.rpy"
        );

        string text = File.ReadAllText(renpyFileName);

        AntlrInputStream inputStream = new(text);
        RenpyLexer speakLexer = new(inputStream);
        CommonTokenStream commonTokenStream = new(speakLexer);
        RenpyParser parser = new(commonTokenStream);

        PrintingRenpyParserListener renpyListener = new();
        ParserErrorListener errorListener = new();
        parser.AddErrorListener(errorListener);
        ParseTreeWalker.Default.Walk(renpyListener, parser.entire_tree());
        Console.WriteLine("");
        //(RenpyListener renpyListener, ParserErrorListener errorListener) = Parse("test004__say.rpy");

        //Assert.Empty(errorListener.Errors);

        //var labels = renpyListener.Script.Labels;
        //Assert.Empty(labels);

        //var instructions = renpyListener.Script.Instructions;
        //Assert.Single(instructions);

        //Assert.Equal(typeof(Say), instructions[0].GetType());
        //Say instruction = (Say)instructions[0];
        //Assert.Equal("Some words in the text box.", instruction.Text);
        //Assert.Equal("Narrator", instruction.Speaker);
    }
}
