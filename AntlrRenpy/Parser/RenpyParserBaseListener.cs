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
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IRenpyParserListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.Diagnostics.DebuggerNonUserCode]
[System.CLSCompliant(false)]
public partial class RenpyParserBaseListener : IRenpyParserListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.entire_tree"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEntire_tree([NotNull] RenpyParser.Entire_treeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.entire_tree"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEntire_tree([NotNull] RenpyParser.Entire_treeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.statements"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStatements([NotNull] RenpyParser.StatementsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.statements"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStatements([NotNull] RenpyParser.StatementsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStatement([NotNull] RenpyParser.StatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStatement([NotNull] RenpyParser.StatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.block_statements"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBlock_statements([NotNull] RenpyParser.Block_statementsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.block_statements"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBlock_statements([NotNull] RenpyParser.Block_statementsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.simple_statements"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSimple_statements([NotNull] RenpyParser.Simple_statementsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.simple_statements"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSimple_statements([NotNull] RenpyParser.Simple_statementsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.python_one_line"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPython_one_line([NotNull] RenpyParser.Python_one_lineContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.python_one_line"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPython_one_line([NotNull] RenpyParser.Python_one_lineContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.block"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBlock([NotNull] RenpyParser.BlockContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.block"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBlock([NotNull] RenpyParser.BlockContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.menu"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMenu([NotNull] RenpyParser.MenuContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.menu"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMenu([NotNull] RenpyParser.MenuContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.menu_item"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMenu_item([NotNull] RenpyParser.Menu_itemContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.menu_item"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMenu_item([NotNull] RenpyParser.Menu_itemContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.pass_statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPass_statement([NotNull] RenpyParser.Pass_statementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.pass_statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPass_statement([NotNull] RenpyParser.Pass_statementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.label"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLabel([NotNull] RenpyParser.LabelContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.label"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLabel([NotNull] RenpyParser.LabelContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.label_name"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLabel_name([NotNull] RenpyParser.Label_nameContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.label_name"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLabel_name([NotNull] RenpyParser.Label_nameContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.jump"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterJump([NotNull] RenpyParser.JumpContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.jump"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitJump([NotNull] RenpyParser.JumpContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.call"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCall([NotNull] RenpyParser.CallContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.call"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCall([NotNull] RenpyParser.CallContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.return"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterReturn([NotNull] RenpyParser.ReturnContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.return"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitReturn([NotNull] RenpyParser.ReturnContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.return_simple"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterReturn_simple([NotNull] RenpyParser.Return_simpleContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.return_simple"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitReturn_simple([NotNull] RenpyParser.Return_simpleContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.say"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSay([NotNull] RenpyParser.SayContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.say"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSay([NotNull] RenpyParser.SayContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.assignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssignment([NotNull] RenpyParser.AssignmentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.assignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssignment([NotNull] RenpyParser.AssignmentContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.augassign"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAugassign([NotNull] RenpyParser.AugassignContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.augassign"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAugassign([NotNull] RenpyParser.AugassignContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.parameters"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParameters([NotNull] RenpyParser.ParametersContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.parameters"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParameters([NotNull] RenpyParser.ParametersContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.kwds"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterKwds([NotNull] RenpyParser.KwdsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.kwds"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitKwds([NotNull] RenpyParser.KwdsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.param_no_default"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParam_no_default([NotNull] RenpyParser.Param_no_defaultContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.param_no_default"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParam_no_default([NotNull] RenpyParser.Param_no_defaultContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.param_with_default"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParam_with_default([NotNull] RenpyParser.Param_with_defaultContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.param_with_default"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParam_with_default([NotNull] RenpyParser.Param_with_defaultContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.param"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParam([NotNull] RenpyParser.ParamContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.param"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParam([NotNull] RenpyParser.ParamContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.annotation"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAnnotation([NotNull] RenpyParser.AnnotationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.annotation"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAnnotation([NotNull] RenpyParser.AnnotationContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.default_assignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDefault_assignment([NotNull] RenpyParser.Default_assignmentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.default_assignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDefault_assignment([NotNull] RenpyParser.Default_assignmentContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.type_comment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterType_comment([NotNull] RenpyParser.Type_commentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.type_comment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitType_comment([NotNull] RenpyParser.Type_commentContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.if_stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIf_stmt([NotNull] RenpyParser.If_stmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.if_stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIf_stmt([NotNull] RenpyParser.If_stmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.elif_stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterElif_stmt([NotNull] RenpyParser.Elif_stmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.elif_stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitElif_stmt([NotNull] RenpyParser.Elif_stmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.else_block"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterElse_block([NotNull] RenpyParser.Else_blockContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.else_block"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitElse_block([NotNull] RenpyParser.Else_blockContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.while_stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterWhile_stmt([NotNull] RenpyParser.While_stmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.while_stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitWhile_stmt([NotNull] RenpyParser.While_stmtContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.list"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterList([NotNull] RenpyParser.ListContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.list"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitList([NotNull] RenpyParser.ListContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.tuple"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTuple([NotNull] RenpyParser.TupleContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.tuple"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTuple([NotNull] RenpyParser.TupleContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.set"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSet([NotNull] RenpyParser.SetContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.set"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSet([NotNull] RenpyParser.SetContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.dict"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDict([NotNull] RenpyParser.DictContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.dict"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDict([NotNull] RenpyParser.DictContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.double_starred_kvpairs"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDouble_starred_kvpairs([NotNull] RenpyParser.Double_starred_kvpairsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.double_starred_kvpairs"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDouble_starred_kvpairs([NotNull] RenpyParser.Double_starred_kvpairsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.double_starred_kvpair"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDouble_starred_kvpair([NotNull] RenpyParser.Double_starred_kvpairContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.double_starred_kvpair"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDouble_starred_kvpair([NotNull] RenpyParser.Double_starred_kvpairContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.kvpair"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterKvpair([NotNull] RenpyParser.KvpairContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.kvpair"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitKvpair([NotNull] RenpyParser.KvpairContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.star_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStar_expression([NotNull] RenpyParser.Star_expressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.star_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStar_expression([NotNull] RenpyParser.Star_expressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExpression([NotNull] RenpyParser.ExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExpression([NotNull] RenpyParser.ExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.comparison"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterComparison([NotNull] RenpyParser.ComparisonContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.comparison"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitComparison([NotNull] RenpyParser.ComparisonContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.bitwise_or"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBitwise_or([NotNull] RenpyParser.Bitwise_orContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.bitwise_or"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBitwise_or([NotNull] RenpyParser.Bitwise_orContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.sum"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSum([NotNull] RenpyParser.SumContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.sum"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSum([NotNull] RenpyParser.SumContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.primary"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPrimary([NotNull] RenpyParser.PrimaryContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.primary"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPrimary([NotNull] RenpyParser.PrimaryContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.atom"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAtom([NotNull] RenpyParser.AtomContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.atom"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAtom([NotNull] RenpyParser.AtomContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.strings"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStrings([NotNull] RenpyParser.StringsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.strings"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStrings([NotNull] RenpyParser.StringsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.single_target"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSingle_target([NotNull] RenpyParser.Single_targetContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.single_target"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSingle_target([NotNull] RenpyParser.Single_targetContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.single_subscript_attribute_target"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSingle_subscript_attribute_target([NotNull] RenpyParser.Single_subscript_attribute_targetContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.single_subscript_attribute_target"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSingle_subscript_attribute_target([NotNull] RenpyParser.Single_subscript_attribute_targetContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.t_primary"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterT_primary([NotNull] RenpyParser.T_primaryContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.t_primary"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitT_primary([NotNull] RenpyParser.T_primaryContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.genexp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterGenexp([NotNull] RenpyParser.GenexpContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.genexp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitGenexp([NotNull] RenpyParser.GenexpContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.arguments"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterArguments([NotNull] RenpyParser.ArgumentsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.arguments"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitArguments([NotNull] RenpyParser.ArgumentsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.args"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterArgs([NotNull] RenpyParser.ArgsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.args"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitArgs([NotNull] RenpyParser.ArgsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.kwargs"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterKwargs([NotNull] RenpyParser.KwargsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.kwargs"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitKwargs([NotNull] RenpyParser.KwargsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.starred_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStarred_expression([NotNull] RenpyParser.Starred_expressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.starred_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStarred_expression([NotNull] RenpyParser.Starred_expressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.kwarg_or_double_starred"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterKwarg_or_double_starred([NotNull] RenpyParser.Kwarg_or_double_starredContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.kwarg_or_double_starred"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitKwarg_or_double_starred([NotNull] RenpyParser.Kwarg_or_double_starredContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.kwarg_or_starred"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterKwarg_or_starred([NotNull] RenpyParser.Kwarg_or_starredContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.kwarg_or_starred"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitKwarg_or_starred([NotNull] RenpyParser.Kwarg_or_starredContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.slices"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSlices([NotNull] RenpyParser.SlicesContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.slices"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSlices([NotNull] RenpyParser.SlicesContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.star_named_expressions"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStar_named_expressions([NotNull] RenpyParser.Star_named_expressionsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.star_named_expressions"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStar_named_expressions([NotNull] RenpyParser.Star_named_expressionsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.star_named_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStar_named_expression([NotNull] RenpyParser.Star_named_expressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.star_named_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStar_named_expression([NotNull] RenpyParser.Star_named_expressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.assignment_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssignment_expression([NotNull] RenpyParser.Assignment_expressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.assignment_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssignment_expression([NotNull] RenpyParser.Assignment_expressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.named_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNamed_expression([NotNull] RenpyParser.Named_expressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.named_expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNamed_expression([NotNull] RenpyParser.Named_expressionContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
