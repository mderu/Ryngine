using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using AntlrRenpy.Listener;

string renpyFileName = args.Length > 0
    ? args[0]
    : Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        "Downloads",
        "sample.rpy"
    );

string text = File.ReadAllText(renpyFileName);

AntlrInputStream inputStream = new(text);
RenpyLexer speakLexer = new (inputStream);
CommonTokenStream commonTokenStream = new(speakLexer);
RenpyParser parser = new(commonTokenStream);

RenpyListener renpyListener = new();
ParserErrorListener errorListener = new();
parser.AddErrorListener(errorListener);
ParseTreeWalker.Default.Walk(renpyListener, parser.entire_tree());
return;
