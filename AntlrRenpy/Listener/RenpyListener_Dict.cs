using Antlr4.Runtime.Misc;
using AntlrRenpy.Program.Expressions;
using AntlrRenpy.Program.Expressions.Operators;
using RynVM.Instructions.Expressions;
using KeyValuePair = AntlrRenpy.Program.Expressions.KeyValuePair;

namespace AntlrRenpy.Listener;

public partial class RenpyListener : RenpyParserBaseListener
{
    /// <remarks>
    /// Each element is either a <see cref="KeyValuePair"/> or <see cref="UnaryDoubleStar"/>.
    /// </remarks>
    private Stack<List<IExpression>> DictEntries { get; } = [];

    public override void EnterDict([NotNull] RenpyParser.DictContext context)
    {
        DictEntries.Push([]);
    }

    public override void ExitDict([NotNull] RenpyParser.DictContext context)
    {
        expressionStack.Push(new DictDefinition(DictEntries.Pop()));
    }

    public override void ExitDouble_starred_kvpair([NotNull] RenpyParser.Double_starred_kvpairContext context)
    {
        if (context.DOUBLESTAR() is not null)
        {
            DictEntries.Peek().Add(new UnaryDoubleStar(expressionStack.Pop()));
        }
        else
        {
            IExpression rightSide = expressionStack.Pop();
            IExpression leftSide = expressionStack.Pop();
            DictEntries.Peek().Add(new KeyValuePair(leftSide, rightSide));
        }
    }
}
