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
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="RenpyParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface IRenpyParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.entire_tree"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEntire_tree([NotNull] RenpyParser.Entire_treeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.statements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatements([NotNull] RenpyParser.StatementsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] RenpyParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.block_statements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlock_statements([NotNull] RenpyParser.Block_statementsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.simple_statements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSimple_statements([NotNull] RenpyParser.Simple_statementsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlock([NotNull] RenpyParser.BlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.menu"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMenu([NotNull] RenpyParser.MenuContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.menu_item"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMenu_item([NotNull] RenpyParser.Menu_itemContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.pass_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPass_statement([NotNull] RenpyParser.Pass_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.label"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLabel([NotNull] RenpyParser.LabelContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.label_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLabel_constant([NotNull] RenpyParser.Label_constantContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.label_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLabel_name([NotNull] RenpyParser.Label_nameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.jump"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitJump([NotNull] RenpyParser.JumpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.jump_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitJump_constant([NotNull] RenpyParser.Jump_constantContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCall([NotNull] RenpyParser.CallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.call_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCall_constant([NotNull] RenpyParser.Call_constantContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.return"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturn([NotNull] RenpyParser.ReturnContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.return_simple"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturn_simple([NotNull] RenpyParser.Return_simpleContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.say"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSay([NotNull] RenpyParser.SayContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment([NotNull] RenpyParser.AssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] RenpyParser.ExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.sum"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSum([NotNull] RenpyParser.SumContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.primary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrimary([NotNull] RenpyParser.PrimaryContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAtom([NotNull] RenpyParser.AtomContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.strings"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStrings([NotNull] RenpyParser.StringsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.assignment_lhs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment_lhs([NotNull] RenpyParser.Assignment_lhsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.data_accessor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitData_accessor([NotNull] RenpyParser.Data_accessorContext context);
}
