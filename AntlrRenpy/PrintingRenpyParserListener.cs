using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Xml.Linq;

namespace AntlrRenpy
{
    public class PrintingRenpyParserListener : IRenpyParserListener
    {
        public record class Entry(string contextName, string contents);

        public List<Entry> Stack = [];

        public void EnterBlock([NotNull] RenpyParser.BlockContext context)
        {
            Stack.Add(new(nameof(EnterBlock), context.GetText()));
        }

        public void EnterCall([NotNull] RenpyParser.CallContext context)
        {
            Stack.Add(new(nameof(EnterCall), context.GetText()));
        }

        public void EnterCall_constant([NotNull] RenpyParser.Call_constantContext context)
        {
            Stack.Add(new(nameof(EnterCall_constant), context.GetText()));
        }

        public void EnterEntire_tree([NotNull] RenpyParser.Entire_treeContext context)
        {
            Stack.Add(new(nameof(EnterEntire_tree), context.GetText()));
        }

        public void EnterEveryRule(ParserRuleContext ctx)
        {
            //Stack.Add(new(nameof(EnterEveryRule), context.GetText()));
        }

        public void EnterJump([NotNull] RenpyParser.JumpContext context)
        {
            Stack.Add(new(nameof(EnterJump), context.GetText()));
        }

        public void EnterJump_constant([NotNull] RenpyParser.Jump_constantContext context)
        {
            Stack.Add(new(nameof(EnterJump_constant), context.GetText()));
        }

        public void EnterLabel([NotNull] RenpyParser.LabelContext context)
        {
            Stack.Add(new(nameof(EnterLabel), context.GetText()));
        }

        public void EnterLabel_constant([NotNull] RenpyParser.Label_constantContext context)
        {
            Stack.Add(new(nameof(EnterLabel_constant), context.GetText()));
        }

        public void EnterLabel_name([NotNull] RenpyParser.Label_nameContext context)
        {
            Stack.Add(new(nameof(EnterLabel_name), context.GetText()));
        }

        public void EnterMenu([NotNull] RenpyParser.MenuContext context)
        {
            Stack.Add(new(nameof(EnterMenu), context.GetText()));
        }

        public void EnterMenu_item([NotNull] RenpyParser.Menu_itemContext context)
        {
            Stack.Add(new(nameof(EnterMenu_item), context.GetText()));
        }

        public void EnterPass_statement([NotNull] RenpyParser.Pass_statementContext context)
        {
            Stack.Add(new(nameof(EnterPass_statement), context.GetText()));
        }

        public void EnterReturn([NotNull] RenpyParser.ReturnContext context)
        {
            Stack.Add(new(nameof(EnterReturn), context.GetText()));
        }

        public void EnterReturn_simple([NotNull] RenpyParser.Return_simpleContext context)
        {
            Stack.Add(new(nameof(EnterReturn_simple), context.GetText()));
        }

        public void EnterSay([NotNull] RenpyParser.SayContext context)
        {
            Stack.Add(new(nameof(EnterSay), context.GetText()));
        }

        public void EnterSimple_statements([NotNull] RenpyParser.Simple_statementsContext context)
        {
            Stack.Add(new(nameof(EnterSimple_statements), context.GetText()));
        }

        public void EnterStatement([NotNull] RenpyParser.StatementContext context)
        {
            Stack.Add(new(nameof(EnterStatement), context.GetText()));
        }

        public void EnterStatements([NotNull] RenpyParser.StatementsContext context)
        {
            Stack.Add(new(nameof(EnterStatements), context.GetText()));
        }

        public void ExitBlock([NotNull] RenpyParser.BlockContext context)
        {
            Stack.Add(new(nameof(ExitBlock), context.GetText()));
        }

        public void ExitCall([NotNull] RenpyParser.CallContext context)
        {
            Stack.Add(new(nameof(ExitCall), context.GetText()));
        }

        public void ExitCall_constant([NotNull] RenpyParser.Call_constantContext context)
        {
            Stack.Add(new(nameof(ExitCall_constant), context.GetText()));
        }

        public void ExitEntire_tree([NotNull] RenpyParser.Entire_treeContext context)
        {
            Stack.Add(new(nameof(ExitEntire_tree), context.GetText()));
        }

        public void ExitEveryRule(ParserRuleContext ctx)
        {
            //Stack.Add(new(nameof(ExitEveryRule), context.GetText()));
        }

        public void ExitJump([NotNull] RenpyParser.JumpContext context)
        {
            Stack.Add(new(nameof(ExitJump), context.GetText()));
        }

        public void ExitJump_constant([NotNull] RenpyParser.Jump_constantContext context)
        {
            Stack.Add(new(nameof(ExitJump_constant), context.GetText()));
        }

        public void ExitLabel([NotNull] RenpyParser.LabelContext context)
        {
            Stack.Add(new(nameof(ExitLabel), context.GetText()));
        }

        public void ExitLabel_constant([NotNull] RenpyParser.Label_constantContext context)
        {
            Stack.Add(new(nameof(ExitLabel_constant), context.GetText()));
        }

        public void ExitLabel_name([NotNull] RenpyParser.Label_nameContext context)
        {
            Stack.Add(new(nameof(ExitLabel_name), context.GetText()));
        }

        public void ExitMenu([NotNull] RenpyParser.MenuContext context)
        {
            Stack.Add(new(nameof(ExitMenu), context.GetText()));
        }

        public void ExitMenu_item([NotNull] RenpyParser.Menu_itemContext context)
        {
            Stack.Add(new(nameof(ExitMenu_item), context.GetText()));
        }

        public void ExitPass_statement([NotNull] RenpyParser.Pass_statementContext context)
        {
            Stack.Add(new(nameof(ExitPass_statement), context.GetText()));
        }

        public void ExitReturn([NotNull] RenpyParser.ReturnContext context)
        {
            Stack.Add(new(nameof(ExitReturn), context.GetText()));
        }

        public void ExitReturn_simple([NotNull] RenpyParser.Return_simpleContext context)
        {
            Stack.Add(new(nameof(ExitReturn_simple), context.GetText()));
        }

        public void ExitSay([NotNull] RenpyParser.SayContext context)
        {
            Stack.Add(new(nameof(ExitSay), context.GetText()));
        }

        public void ExitSimple_statements([NotNull] RenpyParser.Simple_statementsContext context)
        {
            Stack.Add(new(nameof(ExitSimple_statements), context.GetText()));
        }

        public void ExitStatement([NotNull] RenpyParser.StatementContext context)
        {
            Stack.Add(new(nameof(ExitStatement), context.GetText()));
        }

        public void ExitStatements([NotNull] RenpyParser.StatementsContext context)
        {
            Stack.Add(new(nameof(ExitStatements), context.GetText()));
        }

        public void VisitErrorNode(IErrorNode node)
        {
            Stack.Add(new(nameof(VisitErrorNode), node.GetText()));
        }

        public void VisitTerminal(ITerminalNode node)
        {
            Stack.Add(new(nameof(VisitTerminal), node.GetText()));
        }

        public void EnterBlock_statements([NotNull] RenpyParser.Block_statementsContext context)
        {
            Stack.Add(new(nameof(EnterBlock_statements), context.GetText()));
        }

        public void ExitBlock_statements([NotNull] RenpyParser.Block_statementsContext context)
        {
            Stack.Add(new(nameof(ExitBlock_statements), context.GetText()));
        }
    }
}
