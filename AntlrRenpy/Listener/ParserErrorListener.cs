using Antlr4.Runtime;

namespace AntlrRenpy.Listener;

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
        errors.Add(new ParseError
        {
            Exception = e,
            Line = line,
            Column = charPositionInLine,
            SourceName = recognizer.InputStream.SourceName,
            Message = msg,
        });
    }
}
