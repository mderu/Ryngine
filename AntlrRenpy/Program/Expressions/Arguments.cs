namespace AntlrRenpy.Program.Expressions
{
    // TODO: Argument ordering can be interpersed: callFunc(arg1, *arg2, named=arg3, *arg4)
    public class Arguments(
        IEnumerable<IExpression>? arguments = null,
        IEnumerable<(string, IExpression)>? keywordArguments = null,
        IExpression? starArguments = null,
        IExpression? starStarKeywordArguments = null)
            : IExpression
    {
        public IEnumerable<IExpression>? OrderedArguments { get; } = arguments;
        // Note: order is preserved in Python 3.6+.
        public IEnumerable<(string, IExpression)>? KeywordArguments { get; } = keywordArguments;
        public IExpression? StarArguments { get; } = starArguments;
        public IExpression? StarStarKeywordArguments { get; } = starStarKeywordArguments;
    }
}
