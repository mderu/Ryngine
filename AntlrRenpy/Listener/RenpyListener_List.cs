using Antlr4.Runtime.Misc;
using AntlrRenpy.Program.Expressions;
using AntlrRenpy.Program.Expressions.Operators;
using KeyValuePair = AntlrRenpy.Program.Expressions.KeyValuePair;

namespace AntlrRenpy.Listener
{
    public partial class RenpyListener : RenpyParserBaseListener
    {
        /// <remarks>
        /// Each element is either a <see cref="KeyValuePair"/> or <see cref="UnaryDoubleStar"/>.
        /// </remarks>
        private Stack<List<IExpression>> ListEntries { get; } = [];

        public override void ExitStar_named_expression([NotNull] RenpyParser.Star_named_expressionContext context)
        {
            if (context.STAR() is not null)
            {
                ListEntries.Peek().Add(new UnaryStar(expressionStack.Pop()));
            }
            else if (context.named_expression() is not null)
            {
                ListEntries.Peek().Add(expressionStack.Pop());
            }
            else
            {
                throw new NotImplementedException("Unexpected star_named_expression path.");
            }
        }

        public override void EnterList([NotNull] RenpyParser.ListContext context)
        {
            ListEntries.Push([]);
        }

        public override void EnterTuple([NotNull] RenpyParser.TupleContext context)
        {
            ListEntries.Push([]);
        }

        public override void ExitList([NotNull] RenpyParser.ListContext context)
        {
            expressionStack.Push(new ListDefinition(ListEntries.Pop()));
        }

        public override void ExitTuple([NotNull] RenpyParser.TupleContext context)
        {
            // Assume tuples and lists are the same for now. We can figure out the difference later.
            expressionStack.Push(new ListDefinition(ListEntries.Pop()));
        }
    }
}
