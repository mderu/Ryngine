namespace AntlrRenpyTests;

using Xunit;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using AntlrRenpy;
using AntlrRenpy.Program.Instructions;
using Assert = Xunit.Assert;
using System.Diagnostics;
using AntlrRenpy.Program.Expressions;
using AntlrRenpy.Program.Expressions.Operators;
using AntlrRenpy.Listener;

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
            (item) => { Assert.Equal("myLabelName", item.Key); Assert.Equal(2, item.Value.InstructionIndex); },
            (item) => { Assert.Equal("otherLabel", item.Key); Assert.Equal(3, item.Value.InstructionIndex); },
            (item) => { Assert.Equal("anotherLabel", item.Key); Assert.Equal(4, item.Value.InstructionIndex); },
            (item) => { Assert.Equal("multiLabel0", item.Key); Assert.Equal(5, item.Value.InstructionIndex); },
            (item) => { Assert.Equal("multiLabel1", item.Key); Assert.Equal(5, item.Value.InstructionIndex); },
            (item) => { Assert.Equal("multiLabel2", item.Key); Assert.Equal(5, item.Value.InstructionIndex); }
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
            (item) => { Assert.Equal("myLabel", item.Key); Assert.Equal(1, item.Value.InstructionIndex); },
            (item) => { Assert.Equal("skipMyLabel", item.Key); Assert.Equal(3, item.Value.InstructionIndex); }
        );

        var instructions = renpyListener.Script.Instructions;
        Assert.Collection(instructions,
            (item) => Assert.Equal(typeof(JumpConstant), item.GetType()),
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
            (item) => Assert.Equal(typeof(ReturnSimple), item.GetType()),
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
            (item) => Assert.Equal(typeof(PushFrame), item.GetType()),
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
            (item) => { Assert.Equal("expectedMenuLabel", item.Key); Assert.Equal(0, item.Value.InstructionIndex); }
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

                AssertType(assignment.Lhs, out NamedStore namedStore);
                Assert.Equal("a", namedStore.StoreName);

                AssertType(assignment.Rhs, out Constant<bool> constantBool);
                Assert.True(constantBool.Value);
            },
            (item) =>
            {
                AssertType(item, out Assignment assignment);

                AssertType(assignment.Lhs, out NamedStore namedStore);
                Assert.Equal("b", namedStore.StoreName);
                
                AssertType(assignment.Rhs, out Null constantNull);
            },
            (item) =>
            {
                AssertType(item, out Assignment assignment);

                AssertType(assignment.Lhs, out NamedStore namedStore);
                Assert.Equal("name", namedStore.StoreName);

                AssertType(assignment.Rhs, out Constant<string> constantString);
                Assert.Equal("Ryn", constantString.Value);
            },
            (item) =>
            {
                AssertType(item, out Assignment assignment);

                AssertType(assignment.Lhs, out MemberAccess memberAccess);
                Assert.Equal("score", memberAccess.MemberName);
                AssertType(memberAccess.BaseExpression, out NamedStore namedStore);
                Assert.Equal("persistent", namedStore.StoreName);

                AssertType(assignment.Rhs, out ConstantNumber constantNumber);
                Assert.Equal("1.414", constantNumber.Value);
            }
        );
    }

    [Fact]
    public void Test008__sum()
    {
        (RenpyListener renpyListener, ParserErrorListener errorListener) = Parse("test008__sum.rpy");

        Assert.Empty(errorListener.Errors);

        var labels = renpyListener.Script.Labels;
        Assert.Empty(labels);

        var instructions = renpyListener.Script.Instructions;

        Assert.Collection(instructions,
            (item) =>
            {
                AssertType(item, out Assignment assignment);

                AssertType(assignment.Lhs, out NamedStore namedStore);
                Assert.Equal("a", namedStore.StoreName);

                AssertType(assignment.Rhs, out ConstantNumber constNumber);
                Assert.Equal("1", constNumber.Value);
            },
            (item) =>
            {
                AssertType(item, out Assignment assignment);

                AssertType(assignment.Lhs, out NamedStore namedStore);
                Assert.Equal("b", namedStore.StoreName);

                AssertType(assignment.Rhs, out ConstantNumber constNumber);
                Assert.Equal("2", constNumber.Value);
            },
            (item) =>
            {
                AssertType(item, out Assignment assignment);

                AssertType(assignment.Lhs, out NamedStore namedStore);
                Assert.Equal("c", namedStore.StoreName);

                AssertType(assignment.Rhs, out Add firstAdd);
                AssertType(firstAdd.B, out Negate firstNegate);
                AssertType(firstNegate.ExpressionToNegate, out ConstantNumber firstConstant);
                Assert.Equal("0", firstConstant.Value);

                AssertType(firstAdd.A, out Add secondAdd);
                AssertType(secondAdd.B, out Negate secondNegate);
                AssertType(secondNegate.ExpressionToNegate, out NamedStore firstNamedStore);
                Assert.Equal("a", firstNamedStore.StoreName);

                AssertType(secondAdd.A, out Add thirdAdd);
                AssertType(thirdAdd.B, out ConstantNumber secondConstant);
                Assert.Equal("3",  secondConstant.Value);

                AssertType(thirdAdd.A, out Add fourthAdd);
                AssertType(fourthAdd.B, out NamedStore secondNamedStore);
                Assert.Equal("b", secondNamedStore.StoreName);

                AssertType(fourthAdd.A, out NamedStore thirdNamedStore);
                Assert.Equal("a", thirdNamedStore.StoreName);
            }
        );
    }

    [Fact]
    public void Test009__labels_with_args()
    {
        (RenpyListener renpyListener, ParserErrorListener errorListener) = Parse("test009__labels_with_args.rpy");

        Assert.Empty(errorListener.Errors);

        var labels = renpyListener.Script.Labels;
        Assert.Collection(labels,
             (item) =>
             {
                 Assert.Equal("speak", item.Key);
                 Assert.Equal(1, item.Value.InstructionIndex);
             }
        );

        var instructions = renpyListener.Script.Instructions;

        Assert.Collection(instructions,
            (item) =>
            {
                AssertType(item, out PushFrame pushFrame);
                Assert.Equal("speak", pushFrame.LabelName);
                Assert.Collection(pushFrame.Arguments.OrderedArguments,
                    (item) =>
                    {
                        AssertType(item, out Constant<string> constant);
                        Assert.Equal("Hello World!", constant.Value);
                    }
                );
            },
            (item) =>
            {
                AssertType(item, out Say say);
                Assert.Equal("[text]", say.Text);
            },
            (item) =>
            {
                AssertType(item, out ReturnSimple say);
            }
        );
    }

    [Fact]
    public void test010__args_and_params()
    {
        (RenpyListener renpyListener, ParserErrorListener errorListener) = Parse("test010__args_and_params.rpy");

        Assert.Empty(errorListener.Errors);

        var labels = renpyListener.Script.Labels;
        Assert.Collection(labels,
             (item) =>
             {
                 Assert.Equal("speak", item.Key);
                 Assert.Equal(1, item.Value.InstructionIndex);
             }
        );

        var instructions = renpyListener.Script.Instructions;

        Assert.Collection(instructions,
            (item) =>
            {
                AssertType(item, out PushFrame pushFrame);
                Assert.Equal("speak", pushFrame.LabelName);
                Assert.Collection(pushFrame.Arguments.OrderedArguments,
                    (item) =>
                    {
                        AssertType(item, out Constant<string> constant);
                        Assert.Equal("A", constant.Value);
                    },
                    (item) =>
                    {
                        AssertType(item, out UnaryStar unaryStar);
                        AssertType(unaryStar.InnerExpression, out ListDefinition listDefinition);
                        Assert.Single(listDefinition.InnerExpressions);
                        AssertType(listDefinition.InnerExpressions.First(), out Constant<string> constant);
                        Assert.Equal("B", constant.Value);
                    }
                );

                Assert.Collection(pushFrame.Arguments.KeywordArguments,
                    (item) =>
                    {
                        AssertType(item, out NamedArgument namedArgument);
                        Assert.Equal("c", namedArgument.Name);
                        AssertType(namedArgument.Expression, out Constant<string> constant);
                        Assert.Equal("C", constant.Value);
                    },
                    (item) =>
                    {
                        AssertType(item, out UnaryDoubleStar unaryDoubleStar);
                        AssertType(unaryDoubleStar.InnerExpression, out DictDefinition dictDefinition);
                        Assert.Collection(dictDefinition.DictEntries,
                            (item) =>
                            {
                                AssertType(item, out KeyValuePair kvp);
                                AssertType(kvp.Key, out Constant<string> keyConstant);
                                Assert.Equal("d", keyConstant.Value);
                                AssertType(kvp.Value, out Constant<string> valueConstant);
                                Assert.Equal("D", valueConstant.Value);
                            },
                            (item) =>
                            {
                                AssertType(item, out KeyValuePair kvp);
                                AssertType(kvp.Key, out Constant<string> keyConstant);
                                Assert.Equal("f", keyConstant.Value);
                                AssertType(kvp.Value, out Constant<string> valueConstant);
                                Assert.Equal("F", valueConstant.Value);
                            }
                        );
                    },
                    (item) =>
                    {
                        AssertType(item, out NamedArgument namedArgument);
                        Assert.Equal("e", namedArgument.Name);
                        AssertType(namedArgument.Expression, out Constant<string> constant);
                        Assert.Equal("E", constant.Value);
                    }
                );
            },
            (item) =>
            {
                AssertType(item, out Say say);
                Assert.Equal("[a] [b] [c] [d] [e] [kwargs.f]", say.Text);
            },
            (item) =>
            {
                AssertType(item, out ReturnSimple say);
            }
        );
    }
}
