//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:/Users/markd/Documents/GitHub/Ryngine/AntlrRenpy/Parser/RenpyParser.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="RenpyParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface IRenpyParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.entire_tree"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEntire_tree([NotNull] RenpyParser.Entire_treeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.entire_tree"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEntire_tree([NotNull] RenpyParser.Entire_treeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.statements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatements([NotNull] RenpyParser.StatementsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.statements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatements([NotNull] RenpyParser.StatementsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] RenpyParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] RenpyParser.StatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.block_statements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlock_statements([NotNull] RenpyParser.Block_statementsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.block_statements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlock_statements([NotNull] RenpyParser.Block_statementsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.simple_statements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSimple_statements([NotNull] RenpyParser.Simple_statementsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.simple_statements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSimple_statements([NotNull] RenpyParser.Simple_statementsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlock([NotNull] RenpyParser.BlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlock([NotNull] RenpyParser.BlockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.menu"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMenu([NotNull] RenpyParser.MenuContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.menu"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMenu([NotNull] RenpyParser.MenuContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.menu_item"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMenu_item([NotNull] RenpyParser.Menu_itemContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.menu_item"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMenu_item([NotNull] RenpyParser.Menu_itemContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.pass_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPass_statement([NotNull] RenpyParser.Pass_statementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.pass_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPass_statement([NotNull] RenpyParser.Pass_statementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.label"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLabel([NotNull] RenpyParser.LabelContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.label"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLabel([NotNull] RenpyParser.LabelContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.label_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLabel_constant([NotNull] RenpyParser.Label_constantContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.label_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLabel_constant([NotNull] RenpyParser.Label_constantContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.label_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLabel_name([NotNull] RenpyParser.Label_nameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.label_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLabel_name([NotNull] RenpyParser.Label_nameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.jump"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterJump([NotNull] RenpyParser.JumpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.jump"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitJump([NotNull] RenpyParser.JumpContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.jump_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterJump_constant([NotNull] RenpyParser.Jump_constantContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.jump_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitJump_constant([NotNull] RenpyParser.Jump_constantContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCall([NotNull] RenpyParser.CallContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCall([NotNull] RenpyParser.CallContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.call_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCall_constant([NotNull] RenpyParser.Call_constantContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.call_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCall_constant([NotNull] RenpyParser.Call_constantContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.return"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReturn([NotNull] RenpyParser.ReturnContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.return"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReturn([NotNull] RenpyParser.ReturnContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.return_simple"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReturn_simple([NotNull] RenpyParser.Return_simpleContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.return_simple"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReturn_simple([NotNull] RenpyParser.Return_simpleContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.say"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSay([NotNull] RenpyParser.SayContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.say"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSay([NotNull] RenpyParser.SayContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignment([NotNull] RenpyParser.AssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignment([NotNull] RenpyParser.AssignmentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression([NotNull] RenpyParser.ExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression([NotNull] RenpyParser.ExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.sum"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSum([NotNull] RenpyParser.SumContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.sum"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSum([NotNull] RenpyParser.SumContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.primary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrimary([NotNull] RenpyParser.PrimaryContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.primary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrimary([NotNull] RenpyParser.PrimaryContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAtom([NotNull] RenpyParser.AtomContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAtom([NotNull] RenpyParser.AtomContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.strings"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStrings([NotNull] RenpyParser.StringsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.strings"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStrings([NotNull] RenpyParser.StringsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.assignment_lhs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignment_lhs([NotNull] RenpyParser.Assignment_lhsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.assignment_lhs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignment_lhs([NotNull] RenpyParser.Assignment_lhsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.data_accessor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterData_accessor([NotNull] RenpyParser.Data_accessorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.data_accessor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitData_accessor([NotNull] RenpyParser.Data_accessorContext context);
}
