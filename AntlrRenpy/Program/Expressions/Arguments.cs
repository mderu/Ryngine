using AntlrRenpy.Program.Expressions.Operators;

namespace AntlrRenpy.Program.Expressions
{
    /// <remarks>
    /// Target edge case:
    /// 
    ///     >>> def A(a, b, c, d, **kwargs):
    ///     ...     return (a, b, c, d, kwargs)
    ///     ...
    ///     >>> A(b='a', *['b'], **{'c': 'c', 'e': 'e'}, d='d')
    ///     ('b', 'a', 'c', 'd', {'e': 'e'})
    ///     >>> A(a='a', *['b'], **{'c': 'c', 'e': 'e'}, d='d')
    ///     Traceback(most recent call last) :
    ///       File "<stdin>", line 1, in <module>
    ///     TypeError: A() got multiple values for argument 'a'
    /// 
    /// Keyword arguments can be anywhere, but their order relative to OrderedArguments/*args is ignored.
    /// </remarks>
    public record class Arguments(
        IEnumerable<IExpression>? orderedArguments = null,
        IEnumerable<IExpression>? keywordArguments = null)
            : IExpression
    {
        /// <remarks>
        /// May include <see cref="UnaryStar"/> expressions that need to be expanded.
        /// </remarks>
        public IEnumerable<IExpression> OrderedArguments { get; } = orderedArguments ?? [];

        /// <remarks>
        /// Order is preserved in Python 3.6+. 
        /// May include <see cref="UnaryDoubleStar"/> expressions that need to be expanded. In the case
        /// of <see cref="UnaryDoubleStar"/> expressions, the string may be empty or null.
        /// </remarks>
        public IEnumerable<IExpression> KeywordArguments { get; } = keywordArguments ?? [];
    }
}
