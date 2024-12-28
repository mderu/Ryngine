using AntlrRenpy.Program.Expressions.Operators;
using RynVM.Instructions;
using RynVM.Instructions.Expressions;
using RynVM.Script;

namespace AntlrRenpy.Program.Expressions;

/// <param name="OrderedArguments">
///     <remarks>
///     May include <see cref="UnaryStar"/> expressions that need to be expanded.
///     </remarks>
/// </param>
/// 
/// <param name="KeywordArguments">
/// <remarks>
/// Order is preserved in Python 3.6+. 
/// May include <see cref="UnaryDoubleStar"/> expressions that need to be expanded. In the case
/// of <see cref="UnaryDoubleStar"/> expressions, the string may be empty or null.
/// </remarks>
/// </param>
/// 
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
    IEnumerable<IExpression> OrderedArguments,
    IEnumerable<IExpression> KeywordArguments)
        : IAtomic
{
    IAtomic IExpression.EvaluateValue(Store<string, IAtomic> store)
    {
        // https://docs.python.org/3/reference/expressions.html#evaluation-order
        return new Arguments(
            OrderedArguments: OrderedArguments.Select(expr => expr.EvaluateValue(store)),
            KeywordArguments: KeywordArguments.Select(kwarg => kwarg.EvaluateValue(store))
        );
    }
}
