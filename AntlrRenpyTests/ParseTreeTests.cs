namespace AntlrRenpyTests;

using Xunit;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using AntlrRenpy;
using AntlrRenpy.Program.Instructions;
using Assert = Xunit.Assert;
using System.Diagnostics;
using System.Reflection.Metadata;
using AntlrRenpy.Program.Expressions;
using AntlrRenpy.Program.Expressions.Operators;

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

    [Conditional("DEBUG")]
    private static void PrintParseTree(string testFile)
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

        PrintingRenpyParserListener renpyListener = new();
        ParserErrorListener errorListener = new();
        parser.AddErrorListener(errorListener);
        ParseTreeWalker.Default.Walk(renpyListener, parser.entire_tree());
        return;
    }

    public (RenpyListener, ParserErrorListener) Parse(string testFile)
    {
        if (Debugger.IsAttached)
        {
            PrintParseTree(testFile);
        }

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
    public void Test000__empty_file()
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
        (RenpyListener renpyListener, ParserErrorListener errorListener) = Parse("test004__say.rpy");

        Assert.Empty(errorListener.Errors);

        var labels = renpyListener.Script.Labels;
        Assert.Empty(labels);

        var instructions = renpyListener.Script.Instructions;

        Assert.Collection(instructions,
            (item) =>
            {
                Assert.True(item is Say);
                Say say = (Say)item;
                Assert.Equal("Some words in the text box.", say.Text);
                Assert.Equal("Narrator", say.Speaker);
            },
            (item) =>
            {
                Assert.True(item is Say);
                Say say = (Say)item;
                Assert.Equal("No speaker here, but it's implied that it is also the narrator.", say.Text);
                Assert.Equal("", say.Speaker);
            }
        );
    }

    [Fact]
    public void Test005__menu()
    {
        (RenpyListener renpyListener, ParserErrorListener errorListener) = Parse("test005__menu.rpy");

        Assert.Empty(errorListener.Errors);

        var labels = renpyListener.Script.Labels;
        Assert.Collection(labels,
            (item) => { Assert.Equal("expectedMenuLabel", item.Key); Assert.Equal(0, item.Value); }
        );

        var instructions = renpyListener.Script.Instructions;

        Assert.Collection(instructions,
            (item) =>
            {
                Assert.True(item is Menu);
                Menu menu = (Menu)item;
                Assert.Equal(1, menu.SayInstructionIndex);
                Assert.Collection(menu.MenuItems,
                    (item) =>
                    {
                        Assert.Equal("This is a menu choice, it ends in a colon. Menu must contain at least one menu choice", item.Caption);
                        Assert.Equal(2, item.StartInstructionIndex);
                        Assert.Equal(3, item.EndInstructionIndex);
                    },
                    (item) =>
                    {
                        Assert.Equal("When the choice is selected, the block of statements is run", item.Caption);
                        Assert.Equal(3, item.StartInstructionIndex);
                        Assert.Equal(5, item.EndInstructionIndex);
                    }
                );
            },
            (item) =>
            {
                Assert.True(item is Say);
                Say say = (Say)item;
                Assert.Equal("There's a single optional say statement here.", say.Text);
                Assert.Equal("Narrator", say.Speaker);
            },
            (item) =>
            {
                Assert.True(item is Say);
                Say say = (Say)item;
                Assert.Equal("Menu choices must be followed by a block of Ren'Py statements.", say.Text);
                Assert.Equal("", say.Speaker);
            },
            (item) =>
            {
                Assert.True(item is Say);
                Say say = (Say)item;
                Assert.Equal("Message that only appears in the second choice.", say.Text);
                Assert.Equal("", say.Speaker);
            },
            (item) =>
            {
                Assert.Equal(typeof(Pass), item.GetType());
            },
            (item) =>
            {
                Assert.True(item is Say);
                Say say = (Say)item;
                Assert.Equal("This instruction is then jumped to.", say.Text);
                Assert.Equal("", say.Speaker);
            }
        );
    }

    [Fact]
    public void Test006__renpy_strings()
    {
        (RenpyListener renpyListener, ParserErrorListener errorListener) = Parse("test006__renpy_strings.rpy");

        Assert.Empty(errorListener.Errors);

        var labels = renpyListener.Script.Labels;
        Assert.Empty(labels);

        var instructions = renpyListener.Script.Instructions;

        Assert.Collection(instructions,
            (item) =>
            {
                Assert.True(item is Say);
                Say say = (Say)item;
                Assert.Equal("This is one string.", say.Text);
                Assert.Equal("", say.Speaker);
            },
            (item) =>
            {
                Assert.True(item is Say);
                Say say = (Say)item;
                Assert.Equal("This string continues\n even when the line ends.", say.Text);
                Assert.Equal("", say.Speaker);
            },
            (item) =>
            {
                Assert.True(item is Say);
                Say say = (Say)item;
                Assert.Equal("This is also a single string,\nthough it's the same in Python so nothing new.\n", say.Text);
                Assert.Equal("", say.Speaker);
            },
            (item) =>
            {
                Assert.True(item is Say);
                Say say = (Say)item;
                Assert.Equal("Single quoted string.", say.Text);
                Assert.Equal("", say.Speaker);
            },
            (item) =>
            {
                Assert.True(item is Say);
                Say say = (Say)item;
                Assert.Equal("Triple-single quoted string.", say.Text);
                Assert.Equal("", say.Speaker);
            }
        );
    }

    public class AssertTrue(bool condition) : IDisposable
    {
        bool Condition { get; } = condition;

        public void Dispose() {}
    }

    public static bool AssertType<T1, T2>(T2 baseType, out T1 convertedType)
    {
        if (baseType is T1 typedAsOther)
        {
            convertedType = typedAsOther;
            return true;
        }
        throw new AssertFailedException($"{baseType} is not of type {typeof(T1)}");
    }

    [Fact]
    public void Test007__assignment()
    {
        (RenpyListener renpyListener, ParserErrorListener errorListener) = Parse("Test007__assignment.rpy");

        Assert.Empty(errorListener.Errors);

        var labels = renpyListener.Script.Labels;
        Assert.Empty(labels);

        var instructions = renpyListener.Script.Instructions;

        Assert.Collection(instructions,
            (item) =>
            {
                AssertType(item, out Assignment assignment);

                AssertType(assignment.Lhs, out Constant<bool> constantBool);
                Assert.True(constantBool.Value);

                AssertType(assignment.Rhs, out NamedStore namedStore);
                Assert.Equal("a", namedStore.StoreName);
            },
            (item) =>
            {
                AssertType(item, out Assignment assignment);
                AssertType(assignment.Lhs, out Null constantNull);

                AssertType(assignment.Rhs, out NamedStore namedStore);
                Assert.Equal("b", namedStore.StoreName);
            },
            (item) =>
            {
                AssertType(item, out Assignment assignment);
                AssertType(assignment.Lhs, out Constant<string> constantString);
                Assert.Equal("Ryn", constantString.Value);

                AssertType(assignment.Rhs, out NamedStore namedStore);
                Assert.Equal("name", namedStore.StoreName);
            },
            (item) =>
            {
                AssertType(item, out Assignment assignment);

                AssertType(assignment.Lhs, out ConstantNumber constantNumber);
                Assert.Equal("1.414", constantNumber.Value);

                AssertType(assignment.Rhs, out MemberAccess memberAccess);
                Assert.Equal("score", memberAccess.MemberName);

                AssertType(memberAccess.BaseExpression, out NamedStore namedStore);
                Assert.Equal("persistent", namedStore.StoreName);
            }
        );
    }
}
