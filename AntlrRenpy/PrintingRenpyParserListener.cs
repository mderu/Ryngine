using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

// Replace:
//
// public void ([A-Za-z_0-9-]+)\(\[NotNull\] RenpyParser.([A-Za-z_0-9-]+) context\)(\r?)\n\s+{\r?\n\s+throw new NotImplementedException\(\);
//
// with:
//
// public void $1([NotNull] RenpyParser.$2 context)$3\n        {$3\n            Stack.Add(new(nameof($1), context.GetText()));

namespace AntlrRenpy
{
    public class PrintingRenpyParserListener : IRenpyParserListener
    {
        public record class Entry(string contextName, string contents);

        public List<Entry> Stack = [];

        public void EnterEntire_tree([NotNull] RenpyParser.Entire_treeContext context)
        {
            Stack.Add(new(nameof(EnterEntire_tree), context.GetText()));
        }

        public void ExitEntire_tree([NotNull] RenpyParser.Entire_treeContext context)
        {
            Stack.Add(new(nameof(ExitEntire_tree), context.GetText()));
        }

        public void EnterStatements([NotNull] RenpyParser.StatementsContext context)
        {
            Stack.Add(new(nameof(EnterStatements), context.GetText()));
        }

        public void ExitStatements([NotNull] RenpyParser.StatementsContext context)
        {
            Stack.Add(new(nameof(ExitStatements), context.GetText()));
        }

        public void EnterStatement([NotNull] RenpyParser.StatementContext context)
        {
            Stack.Add(new(nameof(EnterStatement), context.GetText()));
        }

        public void ExitStatement([NotNull] RenpyParser.StatementContext context)
        {
            Stack.Add(new(nameof(ExitStatement), context.GetText()));
        }

        public void EnterBlock_statements([NotNull] RenpyParser.Block_statementsContext context)
        {
            Stack.Add(new(nameof(EnterBlock_statements), context.GetText()));
        }

        public void ExitBlock_statements([NotNull] RenpyParser.Block_statementsContext context)
        {
            Stack.Add(new(nameof(ExitBlock_statements), context.GetText()));
        }

        public void EnterSimple_statements([NotNull] RenpyParser.Simple_statementsContext context)
        {
            Stack.Add(new(nameof(EnterSimple_statements), context.GetText()));
        }

        public void ExitSimple_statements([NotNull] RenpyParser.Simple_statementsContext context)
        {
            Stack.Add(new(nameof(ExitSimple_statements), context.GetText()));
        }

        public void EnterBlock([NotNull] RenpyParser.BlockContext context)
        {
            Stack.Add(new(nameof(EnterBlock), context.GetText()));
        }

        public void ExitBlock([NotNull] RenpyParser.BlockContext context)
        {
            Stack.Add(new(nameof(ExitBlock), context.GetText()));
        }

        public void EnterMenu([NotNull] RenpyParser.MenuContext context)
        {
            Stack.Add(new(nameof(EnterMenu), context.GetText()));
        }

        public void ExitMenu([NotNull] RenpyParser.MenuContext context)
        {
            Stack.Add(new(nameof(ExitMenu), context.GetText()));
        }

        public void EnterMenu_item([NotNull] RenpyParser.Menu_itemContext context)
        {
            Stack.Add(new(nameof(EnterMenu_item), context.GetText()));
        }

        public void ExitMenu_item([NotNull] RenpyParser.Menu_itemContext context)
        {
            Stack.Add(new(nameof(ExitMenu_item), context.GetText()));
        }

        public void EnterPass_statement([NotNull] RenpyParser.Pass_statementContext context)
        {
            Stack.Add(new(nameof(EnterPass_statement), context.GetText()));
        }

        public void ExitPass_statement([NotNull] RenpyParser.Pass_statementContext context)
        {
            Stack.Add(new(nameof(ExitPass_statement), context.GetText()));
        }

        public void EnterLabel([NotNull] RenpyParser.LabelContext context)
        {
            Stack.Add(new(nameof(EnterLabel), context.GetText()));
        }

        public void ExitLabel([NotNull] RenpyParser.LabelContext context)
        {
            Stack.Add(new(nameof(ExitLabel), context.GetText()));
        }

        public void EnterLabel_name([NotNull] RenpyParser.Label_nameContext context)
        {
            Stack.Add(new(nameof(EnterLabel_name), context.GetText()));
        }

        public void ExitLabel_name([NotNull] RenpyParser.Label_nameContext context)
        {
            Stack.Add(new(nameof(ExitLabel_name), context.GetText()));
        }

        public void EnterJump([NotNull] RenpyParser.JumpContext context)
        {
            Stack.Add(new(nameof(EnterJump), context.GetText()));
        }

        public void ExitJump([NotNull] RenpyParser.JumpContext context)
        {
            Stack.Add(new(nameof(ExitJump), context.GetText()));
        }

        public void EnterJump_constant([NotNull] RenpyParser.Jump_constantContext context)
        {
            Stack.Add(new(nameof(EnterJump_constant), context.GetText()));
        }

        public void ExitJump_constant([NotNull] RenpyParser.Jump_constantContext context)
        {
            Stack.Add(new(nameof(ExitJump_constant), context.GetText()));
        }

        public void EnterCall([NotNull] RenpyParser.CallContext context)
        {
            Stack.Add(new(nameof(EnterCall), context.GetText()));
        }

        public void ExitCall([NotNull] RenpyParser.CallContext context)
        {
            Stack.Add(new(nameof(ExitCall), context.GetText()));
        }

        public void EnterReturn([NotNull] RenpyParser.ReturnContext context)
        {
            Stack.Add(new(nameof(EnterReturn), context.GetText()));
        }

        public void ExitReturn([NotNull] RenpyParser.ReturnContext context)
        {
            Stack.Add(new(nameof(ExitReturn), context.GetText()));
        }

        public void EnterReturn_simple([NotNull] RenpyParser.Return_simpleContext context)
        {
            Stack.Add(new(nameof(EnterReturn_simple), context.GetText()));
        }

        public void ExitReturn_simple([NotNull] RenpyParser.Return_simpleContext context)
        {
            Stack.Add(new(nameof(ExitReturn_simple), context.GetText()));
        }

        public void EnterSay([NotNull] RenpyParser.SayContext context)
        {
            Stack.Add(new(nameof(EnterSay), context.GetText()));
        }

        public void ExitSay([NotNull] RenpyParser.SayContext context)
        {
            Stack.Add(new(nameof(ExitSay), context.GetText()));
        }

        public void EnterAssignment([NotNull] RenpyParser.AssignmentContext context)
        {
            Stack.Add(new(nameof(EnterAssignment), context.GetText()));
        }

        public void ExitAssignment([NotNull] RenpyParser.AssignmentContext context)
        {
            Stack.Add(new(nameof(ExitAssignment), context.GetText()));
        }

        public void EnterExpression([NotNull] RenpyParser.ExpressionContext context)
        {
            Stack.Add(new(nameof(EnterExpression), context.GetText()));
        }

        public void ExitExpression([NotNull] RenpyParser.ExpressionContext context)
        {
            Stack.Add(new(nameof(ExitExpression), context.GetText()));
        }

        public void EnterSum([NotNull] RenpyParser.SumContext context)
        {
            Stack.Add(new(nameof(EnterSum), context.GetText()));
        }

        public void ExitSum([NotNull] RenpyParser.SumContext context)
        {
            Stack.Add(new(nameof(ExitSum), context.GetText()));
        }

        public void EnterPrimary([NotNull] RenpyParser.PrimaryContext context)
        {
            Stack.Add(new(nameof(EnterPrimary), context.GetText()));
        }

        public void ExitPrimary([NotNull] RenpyParser.PrimaryContext context)
        {
            Stack.Add(new(nameof(ExitPrimary), context.GetText()));
        }

        public void EnterAtom([NotNull] RenpyParser.AtomContext context)
        {
            Stack.Add(new(nameof(EnterAtom), context.GetText()));
        }

        public void ExitAtom([NotNull] RenpyParser.AtomContext context)
        {
            Stack.Add(new(nameof(ExitAtom), context.GetText()));
        }

        public void EnterStrings([NotNull] RenpyParser.StringsContext context)
        {
            Stack.Add(new(nameof(EnterStrings), context.GetText()));
        }

        public void ExitStrings([NotNull] RenpyParser.StringsContext context)
        {
            Stack.Add(new(nameof(ExitStrings), context.GetText()));
        }

        public void EnterSingle_target([NotNull] RenpyParser.Single_targetContext context)
        {
            Stack.Add(new(nameof(EnterSingle_target), context.GetText()));
        }

        public void ExitSingle_target([NotNull] RenpyParser.Single_targetContext context)
        {
            Stack.Add(new(nameof(ExitSingle_target), context.GetText()));
        }

        public void EnterSingle_subscript_attribute_target([NotNull] RenpyParser.Single_subscript_attribute_targetContext context)
        {
            Stack.Add(new(nameof(EnterSingle_subscript_attribute_target), context.GetText()));
        }

        public void ExitSingle_subscript_attribute_target([NotNull] RenpyParser.Single_subscript_attribute_targetContext context)
        {
            Stack.Add(new(nameof(ExitSingle_subscript_attribute_target), context.GetText()));
        }

        public void EnterT_primary([NotNull] RenpyParser.T_primaryContext context)
        {
            Stack.Add(new(nameof(EnterT_primary), context.GetText()));
        }

        public void ExitT_primary([NotNull] RenpyParser.T_primaryContext context)
        {
            Stack.Add(new(nameof(ExitT_primary), context.GetText()));
        }

        public void EnterGenexp([NotNull] RenpyParser.GenexpContext context)
        {
            Stack.Add(new(nameof(EnterGenexp), context.GetText()));
        }

        public void ExitGenexp([NotNull] RenpyParser.GenexpContext context)
        {
            Stack.Add(new(nameof(ExitGenexp), context.GetText()));
        }

        public void EnterArguments([NotNull] RenpyParser.ArgumentsContext context)
        {
            Stack.Add(new(nameof(EnterArguments), context.GetText()));
        }

        public void ExitArguments([NotNull] RenpyParser.ArgumentsContext context)
        {
            Stack.Add(new(nameof(ExitArguments), context.GetText()));
        }

        public void EnterArgs([NotNull] RenpyParser.ArgsContext context)
        {
            Stack.Add(new(nameof(EnterArgs), context.GetText()));
        }

        public void ExitArgs([NotNull] RenpyParser.ArgsContext context)
        {
            Stack.Add(new(nameof(ExitArgs), context.GetText()));
        }

        public void EnterKwargs([NotNull] RenpyParser.KwargsContext context)
        {
            Stack.Add(new(nameof(EnterKwargs), context.GetText()));
        }

        public void ExitKwargs([NotNull] RenpyParser.KwargsContext context)
        {
            Stack.Add(new(nameof(ExitKwargs), context.GetText()));
        }

        public void EnterStarred_expression([NotNull] RenpyParser.Starred_expressionContext context)
        {
            Stack.Add(new(nameof(EnterStarred_expression), context.GetText()));
        }

        public void ExitStarred_expression([NotNull] RenpyParser.Starred_expressionContext context)
        {
            Stack.Add(new(nameof(ExitStarred_expression), context.GetText()));
        }

        public void EnterKwarg_or_double_starred([NotNull] RenpyParser.Kwarg_or_double_starredContext context)
        {
            Stack.Add(new(nameof(EnterKwarg_or_double_starred), context.GetText()));
        }

        public void ExitKwarg_or_double_starred([NotNull] RenpyParser.Kwarg_or_double_starredContext context)
        {
            Stack.Add(new(nameof(ExitKwarg_or_double_starred), context.GetText()));
        }

        public void EnterKwarg_or_starred([NotNull] RenpyParser.Kwarg_or_starredContext context)
        {
            Stack.Add(new(nameof(EnterKwarg_or_starred), context.GetText()));
        }

        public void ExitKwarg_or_starred([NotNull] RenpyParser.Kwarg_or_starredContext context)
        {
            Stack.Add(new(nameof(ExitKwarg_or_starred), context.GetText()));
        }

        public void EnterAssignment_expression([NotNull] RenpyParser.Assignment_expressionContext context)
        {
            Stack.Add(new(nameof(EnterAssignment_expression), context.GetText()));
        }

        public void ExitAssignment_expression([NotNull] RenpyParser.Assignment_expressionContext context)
        {
            Stack.Add(new(nameof(ExitAssignment_expression), context.GetText()));
        }

        public void EnterSlices([NotNull] RenpyParser.SlicesContext context)
        {
            Stack.Add(new(nameof(EnterSlices), context.GetText()));
        }

        public void ExitSlices([NotNull] RenpyParser.SlicesContext context)
        {
            Stack.Add(new(nameof(ExitSlices), context.GetText()));
        }

        public void EnterNamed_expression([NotNull] RenpyParser.Named_expressionContext context)
        {
            Stack.Add(new(nameof(EnterNamed_expression), context.GetText()));
        }

        public void ExitNamed_expression([NotNull] RenpyParser.Named_expressionContext context)
        {
            Stack.Add(new(nameof(ExitNamed_expression), context.GetText()));
        }

        public void VisitTerminal(ITerminalNode node)
        {
        }

        public void VisitErrorNode(IErrorNode node)
        {
        }

        public void EnterEveryRule(ParserRuleContext ctx)
        {
        }

        public void ExitEveryRule(ParserRuleContext ctx)
        {
        }
    }
}
