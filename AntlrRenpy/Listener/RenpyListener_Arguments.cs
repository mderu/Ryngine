using Antlr4.Runtime.Tree;
using AntlrRenpy.Program.Expressions;
using AntlrRenpy.Program.Expressions.Operators;
using System.Diagnostics.CodeAnalysis;
using static RenpyParser;

namespace AntlrRenpy.Listener
{
    public partial class RenpyListener : RenpyParserBaseListener
    {
        public override void ExitArgs([NotNull] ArgsContext context)
        {
            Arguments? kwargs = null;
            Stack<IExpression> argStack = [];
            if (context.kwargs() is not null)
            {
                kwargs = (Arguments)expressionStack.Pop();
            }

            int totalOrderedArgs = context.starred_expression().Length
                + context.assignment_expression().Length
                + context.expression().Length;

            for (int index = totalOrderedArgs; index > 0; index--)
            {
                argStack.Push(expressionStack.Pop());
            }

            expressionStack.Push(new Arguments(
                arguments: [.. argStack, .. kwargs?.OrderedArguments ?? []],
                keywordArguments: kwargs?.KeywordArguments));
        }

        public override void ExitKwargs([NotNull] KwargsContext context)
        {
            Stack<IExpression> args = [];
            Stack<IExpression> kwargs = [];
            int expressionCount = context.kwarg_or_double_starred().Length + context.kwarg_or_starred().Length;
            for (int index = expressionCount; index > 0; index--)
            {
                IExpression expression = expressionStack.Pop();

                (expression switch
                {
                    UnaryStar _ => args,
                    NamedArgument _ => kwargs,
                    UnaryDoubleStar _ => kwargs,
                    _ => throw new InvalidCastException($"Uncertain what type of argument {expression.GetType()} is."),
                }).Push(expression);
            }

            // Stacks iterate in Pop() order. This flips the args & kwargs.
            expressionStack.Push(new Arguments([.. args], [.. kwargs]));
        }

        public override void ExitKwarg_or_starred([NotNull] Kwarg_or_starredContext context)
        {
            if (context.NAME() is ITerminalNode node)
            {
                expressionStack.Push(new NamedArgument(node.GetText(), expressionStack.Pop()));
            }
            // starred_expression can remain in the stack.
        }

        public override void ExitKwarg_or_double_starred([NotNull] Kwarg_or_double_starredContext context)
        {
            if (context.NAME() is ITerminalNode node)
            {
                expressionStack.Push(new NamedArgument(node.GetText(), expressionStack.Pop()));
            }
            else if (context.DOUBLESTAR() is not null)
            {
                expressionStack.Push(new UnaryDoubleStar(expressionStack.Pop()));
            }
        }

        public override void ExitStarred_expression([NotNull] Starred_expressionContext context)
        {
            expressionStack.Push(new UnaryStar(expressionStack.Pop()));
        }
    }
}
