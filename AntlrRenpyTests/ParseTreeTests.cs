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
using AntlrRenpy.Program;
using AntlrRenpy.Program.ControlFlows;

public class ParseTreeTests
{

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

    public class AssertTrue(bool condition) : IDisposable
    {
        bool Condition { get; } = condition;

        public void Dispose() { }
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
    public void Test000__empty_file()
    {
        (RenpyListener renpyListener, ParserErrorListener errorListener) = Parse("test000__empty_file.rpy");

        Assert.Empty(errorListener.Errors);
        Assert.Empty(renpyListener.Script.Labels);
        Assert.Collection(renpyListener.Script.Instructions,
            (item) => Assert.Equal(typeof(Pass), item.GetType())
        );
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
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
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
            (item) =>
            {
                Assert.Equal("myLabelName", item.Key);
                Assert.True(item.Value.JumpToEnd);
                Assert.Same(item.Value.Positional, renpyListener.Script.Instructions[2]);
            },
            (item) =>
            {
                Assert.Equal("otherLabel", item.Key);
                Assert.True(item.Value.JumpToEnd);
                Assert.Same(item.Value.Positional, renpyListener.Script.Instructions[3]);
            },
            (item) =>
            {
                Assert.Equal("anotherLabel", item.Key);
                Assert.True(item.Value.JumpToEnd);
                Assert.Same(item.Value.Positional, renpyListener.Script.Instructions[4]);
            },
            (item) =>
            {
                Assert.Equal("multiLabel0", item.Key);
                Assert.True(item.Value.JumpToEnd);
                Assert.Same(item.Value.Positional, renpyListener.Script.Instructions[5]);
            },
            (item) =>
            {
                Assert.Equal("multiLabel1", item.Key);
                Assert.True(item.Value.JumpToEnd);
                Assert.Same(item.Value.Positional, renpyListener.Script.Instructions[5]);
            },
            (item) =>
            {
                Assert.Equal("multiLabel2", item.Key);
                Assert.True(item.Value.JumpToEnd);
                Assert.Same(item.Value.Positional, renpyListener.Script.Instructions[5]);
            }
        );

        var instructions = renpyListener.Script.Instructions;
        Assert.Collection(instructions,
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
            (item) => Assert.Equal(typeof(Jump), item.GetType()),
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
            (item) =>
            {
                Assert.Equal("myLabel", item.Key);
                Assert.True(item.Value.JumpToEnd);
                Assert.Same(item.Value.Positional, renpyListener.Script.Instructions[1]);
            },
            (item) =>
            {
                Assert.Equal("skipMyLabel", item.Key);
                Assert.True(item.Value.JumpToEnd);
                Assert.Same(item.Value.Positional, renpyListener.Script.Instructions[3]);
            }
        );

        var instructions = renpyListener.Script.Instructions;
        Assert.Collection(instructions,
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
            (item) => Assert.Equal(typeof(Jump), item.GetType()),
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
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
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
            (item) =>
            {
                Assert.Equal("expectedMenuLabel", item.Key);
                Assert.False(item.Value.JumpToEnd);
                Assert.Same(renpyListener.Script.Instructions[1], item.Value.Positional);
            }
        );

        var instructions = renpyListener.Script.Instructions;

        Assert.Collection(instructions,
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
            (item) =>
            {
                Assert.True(item is Menu);
                Menu menu = (Menu)item;
                Assert.Collection(menu.SayBlock.Instructions,
                    (item) =>
                    {
                        AssertType(item, out Say say);
                        Assert.Equal("Narrator", say.Speaker);
                        Assert.Equal("There's a single optional say statement here.", say.Text);
                    }
                );
                Assert.Collection(menu.MenuItems,
                    (item) =>
                    {
                        Assert.Equal("This is a menu choice, it ends in a colon. Menu must contain at least one menu choice", item.Caption);
                        Assert.Collection(item.Block.Instructions,
                            (instruction) =>
                            {
                                AssertType(instruction, out Say say);
                                Assert.Equal("", say.Speaker);
                                Assert.Equal("Menu choices must be followed by a block of Ren'Py statements.", say.Text);
                            }
                        );
                    },
                    (item) =>
                    {
                        Assert.Equal("When the choice is selected, the block of statements is run", item.Caption);
                        Assert.Collection(item.Block.Instructions,
                            (instruction) =>
                            {
                                AssertType(instruction, out Say say);
                                Assert.Equal("", say.Speaker);
                                Assert.Equal("Message that only appears in the second choice.", say.Text);
                            },
                            (instruction) =>
                            {
                                AssertType(instruction, out Pass pass);
                            }
                        );
                    }
                );
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
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
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
    
    [Fact]
    public void Test007__assignment()
    {
        (RenpyListener renpyListener, ParserErrorListener errorListener) = Parse("Test007__assignment.rpy");

        Assert.Empty(errorListener.Errors);

        var labels = renpyListener.Script.Labels;
        Assert.Empty(labels);

        var instructions = renpyListener.Script.Instructions;

        Assert.Collection(instructions,
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
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
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
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
        var instructions = renpyListener.Script.Instructions;

        Assert.Collection(labels,
            (item) =>
            {
                Assert.Equal("speak", item.Key);
                Assert.True(item.Value.JumpToEnd);
                Assert.Same(instructions[1], item.Value.Positional);
                Parameters parameters = item.Value.Parameters;
                Assert.Equal(new Parameters(["text"], [], 0, 0), parameters);
            }
        );

        Assert.Collection(instructions,
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
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
    public void Test010__args_and_params()
    {
        (RenpyListener renpyListener, ParserErrorListener errorListener) = Parse("test010__args_and_params.rpy");

        Assert.Empty(errorListener.Errors);

        var labels = renpyListener.Script.Labels;
        var instructions = renpyListener.Script.Instructions;

        Assert.Collection(labels,
            (item) =>
            {
                Assert.Equal("speak", item.Key);
                Assert.True(item.Value.JumpToEnd);
                Assert.Same(instructions[1], item.Value.Positional);
                Parameters parameters = item.Value.Parameters;
                Assert.Equal(new Parameters(["a", "b", "c", "d", "e", "kwargs"], [], 0, 0), parameters);
            }
        );

        Assert.Collection(instructions,
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
            (item) =>
            {
                AssertType(item, out PushFrame pushFrame);
                Assert.Equal("speak", pushFrame.LabelName);
                Assert.Collection(pushFrame.Arguments.OrderedArguments,
                    (item) =>
                    {
                        Assert.Equal(new Constant<string>("A"), item);
                    },
                    (item) =>
                    {
                        AssertType(item, out UnaryStar unaryStar);
                        AssertType(unaryStar.InnerExpression, out ListDefinition listDefinition);
                        Assert.Single(listDefinition.InnerExpressions);
                        Assert.Equal(new Constant<string>("B"), listDefinition.InnerExpressions.First());
                    }
                );

                Assert.Collection(pushFrame.Arguments.KeywordArguments,
                    (item) =>
                    {
                        Assert.Equal(new NamedArgument("c", new Constant<string>("C")), item);
                    },
                    (item) =>
                    {
                        AssertType(item, out UnaryDoubleStar unaryDoubleStar);
                        AssertType(unaryDoubleStar.InnerExpression, out DictDefinition dictDefinition);
                        Assert.Collection(dictDefinition.DictEntries,
                            (item) =>
                            {
                                Assert.Equal(
                                    new KeyValuePair(new Constant<string>("d"), new Constant<string>("D")),
                                    item
                                );
                            },
                            (item) =>
                            {
                                Assert.Equal(
                                    new KeyValuePair(new Constant<string>("f"), new Constant<string>("F")),
                                    item
                                );
                            }
                        );
                    },
                    (item) =>
                    {
                        Assert.Equal(new NamedArgument("e", new Constant<string>("E")), item);
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
    
    [Fact]
    public void Test011__if_elif_else()
    {
        (RenpyListener renpyListener, ParserErrorListener errorListener) = Parse("test011__if_elif_else.rpy");

        Assert.Empty(errorListener.Errors);

        var labels = renpyListener.Script.Labels;
        var instructions = renpyListener.Script.Instructions;

        Assert.Collection(instructions,
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
            (item) =>
            {
                AssertType(item, out If ifStatement);
                Assert.Collection(ifStatement.IfBlock.Instructions,
                    (item) => Assert.Equal(new Say("Not said"), item)
                );

                Assert.NotNull(ifStatement.ElseStatement);
                Assert.Collection(ifStatement.ElseStatement.Block.Instructions,
                    (item) =>
                    {
                        AssertType(item, out If innerIfStatement);
                        Assert.Collection(innerIfStatement.IfBlock.Instructions,
                            (item) => Assert.Equal(new Say("Said"), item)
                        );

                        Assert.NotNull(innerIfStatement.ElseStatement);
                        Assert.Collection(innerIfStatement.ElseStatement.Block.Instructions,
                            (item) => Assert.Equal(new Say("Also not said"), item)
                        );
                    }
                );
            }
        );
    }

    [Fact]
    public void Test012__while()
    {
        (RenpyListener renpyListener, ParserErrorListener errorListener) = Parse("test012__while.rpy");

        Assert.Empty(errorListener.Errors);

        var labels = renpyListener.Script.Labels;
        var instructions = renpyListener.Script.Instructions;

        Assert.Collection(instructions,
            (item) => Assert.Equal(typeof(Pass), item.GetType()),
            (item) =>
            {
                AssertType(item, out Assignment assignment);
                AssertType(assignment.Lhs, out NamedStore namedStore);
                Assert.Equal("count", namedStore.StoreName);
                Assert.Equal(new ConstantNumber("10"), assignment.Rhs);
            },
            (item) =>
            {
                AssertType(item, out While whileStatement);
                
                AssertType(whileStatement.Condition, out Comparison comparison);
                Assert.Equal(Comparison.Type.GreaterThan, comparison.ComparisonType);
                Assert.Equal(new NamedStore("count"), comparison.Lhs);
                Assert.Equal(new ConstantNumber("0"), comparison.Rhs);

                Assert.Collection(whileStatement.Block.Instructions,
                    (item) => Assert.Equal(new Say("T-minus [count]."), item),
                    (item) => {
                        AssertType(item, out Assignment assignment);
                        Assert.Equal(new NamedStore("count"), assignment.Lhs);
                        Assert.Equal(new ConstantNumber("1"), assignment.Rhs);
                        Assert.Equal(Assignment.Type.MinEqual, assignment.AssignmentType);
                    }
                );

                Assert.NotNull(whileStatement.ElseStatement);
                Assert.Collection(whileStatement.ElseStatement.Block.Instructions,
                    (item) => Assert.Equal(new Say("This is triggered if the above while loop isn't broken."), item)
                );
            },
            (item) =>
            {
                Assert.Equal(new Say("Liftoff!"), item);
            }
        );
    }
}
