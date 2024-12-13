using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace AntlrRenpy
{
    public class PrintingRenpyParserListener : RenpyParserBaseListener
    {
        public record class Entry(string contextName, string contents);

        public List<Entry> Stack = [];

        public override void EnterEveryRule(ParserRuleContext ctx)
        {
            Stack.Add(new($"Enter{ctx.GetType().Name}", ctx.GetText()));
        }

        public override void ExitEveryRule(ParserRuleContext ctx)
        {
            Stack.Add(new($"Exit{ctx.GetType().Name}", ctx.GetText()));
        }
    }
}
