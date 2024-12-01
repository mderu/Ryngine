using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace AntlrRenpy
{
    public class PrintingRenpyParserListener : IRenpyParserListener
    {
        public List<string> Stack = new List<string>();
        public void EnterBlock([NotNull] RenpyParser.BlockContext context)
        {
            Stack.Add(nameof(EnterBlock));
        }

        public void EnterCall([NotNull] RenpyParser.CallContext context)
        {
            Stack.Add(nameof(EnterCall));
        }

        public void EnterCall_constant([NotNull] RenpyParser.Call_constantContext context)
        {
            Stack.Add(nameof(EnterCall_constant));
        }

        public void EnterEntire_tree([NotNull] RenpyParser.Entire_treeContext context)
        {
            Stack.Add(nameof(EnterEntire_tree));
        }

        public void EnterEveryRule(ParserRuleContext ctx)
        {
            //Stack.Add(nameof(EnterEveryRule));
        }

        public void EnterJump([NotNull] RenpyParser.JumpContext context)
        {
            Stack.Add(nameof(EnterJump));
        }

        public void EnterJump_constant([NotNull] RenpyParser.Jump_constantContext context)
        {
            Stack.Add(nameof(EnterJump_constant));
        }

        public void EnterLabel([NotNull] RenpyParser.LabelContext context)
        {
            Stack.Add(nameof(EnterLabel));
        }

        public void EnterLabel_constant([NotNull] RenpyParser.Label_constantContext context)
        {
            Stack.Add(nameof(EnterLabel_constant));
        }

        public void EnterLabel_name([NotNull] RenpyParser.Label_nameContext context)
        {
            Stack.Add(nameof(EnterLabel_name));
        }

        public void EnterPass_statement([NotNull] RenpyParser.Pass_statementContext context)
        {
            Stack.Add(nameof(EnterPass_statement));
        }

        public void EnterReturn([NotNull] RenpyParser.ReturnContext context)
        {
            Stack.Add(nameof(EnterReturn));
        }

        public void EnterReturn_simple([NotNull] RenpyParser.Return_simpleContext context)
        {
            Stack.Add(nameof(EnterReturn_simple));
        }

        public void EnterSay([NotNull] RenpyParser.SayContext context)
        {
            Stack.Add(nameof(EnterSay));
        }

        public void EnterSimple_statements([NotNull] RenpyParser.Simple_statementsContext context)
        {
            Stack.Add(nameof(EnterSimple_statements));
        }

        public void EnterStatement([NotNull] RenpyParser.StatementContext context)
        {
            Stack.Add(nameof(EnterStatement));
        }

        public void EnterStatements([NotNull] RenpyParser.StatementsContext context)
        {
            Stack.Add(nameof(EnterStatements));
        }

        public void ExitBlock([NotNull] RenpyParser.BlockContext context)
        {
            Stack.Add(nameof(ExitBlock));
        }

        public void ExitCall([NotNull] RenpyParser.CallContext context)
        {
            Stack.Add(nameof(ExitCall));
        }

        public void ExitCall_constant([NotNull] RenpyParser.Call_constantContext context)
        {
            Stack.Add(nameof(ExitCall_constant));
        }

        public void ExitEntire_tree([NotNull] RenpyParser.Entire_treeContext context)
        {
            Stack.Add(nameof(ExitEntire_tree));
        }

        public void ExitEveryRule(ParserRuleContext ctx)
        {
            //Stack.Add(nameof(ExitEveryRule));
        }

        public void ExitJump([NotNull] RenpyParser.JumpContext context)
        {
            Stack.Add(nameof(ExitJump));
        }

        public void ExitJump_constant([NotNull] RenpyParser.Jump_constantContext context)
        {
            Stack.Add(nameof(ExitJump_constant));
        }

        public void ExitLabel([NotNull] RenpyParser.LabelContext context)
        {
            Stack.Add(nameof(ExitLabel));
        }

        public void ExitLabel_constant([NotNull] RenpyParser.Label_constantContext context)
        {
            Stack.Add(nameof(ExitLabel_constant));
        }

        public void ExitLabel_name([NotNull] RenpyParser.Label_nameContext context)
        {
            Stack.Add(nameof(ExitLabel_name));
        }

        public void ExitPass_statement([NotNull] RenpyParser.Pass_statementContext context)
        {
            Stack.Add(nameof(ExitPass_statement));
        }

        public void ExitReturn([NotNull] RenpyParser.ReturnContext context)
        {
            Stack.Add(nameof(ExitReturn));
        }

        public void ExitReturn_simple([NotNull] RenpyParser.Return_simpleContext context)
        {
            Stack.Add(nameof(ExitReturn_simple));
        }

        public void ExitSay([NotNull] RenpyParser.SayContext context)
        {
            Stack.Add(nameof(ExitSay));
        }

        public void ExitSimple_statements([NotNull] RenpyParser.Simple_statementsContext context)
        {
            Stack.Add(nameof(ExitSimple_statements));
        }

        public void ExitStatement([NotNull] RenpyParser.StatementContext context)
        {
            Stack.Add(nameof(ExitStatement));
        }

        public void ExitStatements([NotNull] RenpyParser.StatementsContext context)
        {
            Stack.Add(nameof(ExitStatements));
        }

        public void VisitErrorNode(IErrorNode node)
        {
            Stack.Add(nameof(VisitErrorNode));
        }

        public void VisitTerminal(ITerminalNode node)
        {
            Stack.Add(nameof(VisitTerminal));
        }
    }
}
