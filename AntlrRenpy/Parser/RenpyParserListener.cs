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
	/// Enter a parse tree produced by <see cref="RenpyParser.parameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParameters([NotNull] RenpyParser.ParametersContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.parameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParameters([NotNull] RenpyParser.ParametersContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.kwds"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterKwds([NotNull] RenpyParser.KwdsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.kwds"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitKwds([NotNull] RenpyParser.KwdsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.param_no_default"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParam_no_default([NotNull] RenpyParser.Param_no_defaultContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.param_no_default"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParam_no_default([NotNull] RenpyParser.Param_no_defaultContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.param_with_default"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParam_with_default([NotNull] RenpyParser.Param_with_defaultContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.param_with_default"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParam_with_default([NotNull] RenpyParser.Param_with_defaultContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.param"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParam([NotNull] RenpyParser.ParamContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.param"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParam([NotNull] RenpyParser.ParamContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAnnotation([NotNull] RenpyParser.AnnotationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAnnotation([NotNull] RenpyParser.AnnotationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.default_assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDefault_assignment([NotNull] RenpyParser.Default_assignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.default_assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDefault_assignment([NotNull] RenpyParser.Default_assignmentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.type_comment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterType_comment([NotNull] RenpyParser.Type_commentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.type_comment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitType_comment([NotNull] RenpyParser.Type_commentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.if_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIf_stmt([NotNull] RenpyParser.If_stmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.if_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIf_stmt([NotNull] RenpyParser.If_stmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.elif_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElif_stmt([NotNull] RenpyParser.Elif_stmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.elif_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElif_stmt([NotNull] RenpyParser.Elif_stmtContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.else_block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElse_block([NotNull] RenpyParser.Else_blockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.else_block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElse_block([NotNull] RenpyParser.Else_blockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterList([NotNull] RenpyParser.ListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitList([NotNull] RenpyParser.ListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.tuple"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTuple([NotNull] RenpyParser.TupleContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.tuple"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTuple([NotNull] RenpyParser.TupleContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.set"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSet([NotNull] RenpyParser.SetContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.set"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSet([NotNull] RenpyParser.SetContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.dict"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDict([NotNull] RenpyParser.DictContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.dict"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDict([NotNull] RenpyParser.DictContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.double_starred_kvpairs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDouble_starred_kvpairs([NotNull] RenpyParser.Double_starred_kvpairsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.double_starred_kvpairs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDouble_starred_kvpairs([NotNull] RenpyParser.Double_starred_kvpairsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.double_starred_kvpair"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDouble_starred_kvpair([NotNull] RenpyParser.Double_starred_kvpairContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.double_starred_kvpair"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDouble_starred_kvpair([NotNull] RenpyParser.Double_starred_kvpairContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.kvpair"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterKvpair([NotNull] RenpyParser.KvpairContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.kvpair"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitKvpair([NotNull] RenpyParser.KvpairContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.star_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStar_expression([NotNull] RenpyParser.Star_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.star_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStar_expression([NotNull] RenpyParser.Star_expressionContext context);
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
	/// Enter a parse tree produced by <see cref="RenpyParser.bitwise_or"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBitwise_or([NotNull] RenpyParser.Bitwise_orContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.bitwise_or"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBitwise_or([NotNull] RenpyParser.Bitwise_orContext context);
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
	/// Enter a parse tree produced by <see cref="RenpyParser.single_target"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSingle_target([NotNull] RenpyParser.Single_targetContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.single_target"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSingle_target([NotNull] RenpyParser.Single_targetContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.single_subscript_attribute_target"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSingle_subscript_attribute_target([NotNull] RenpyParser.Single_subscript_attribute_targetContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.single_subscript_attribute_target"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSingle_subscript_attribute_target([NotNull] RenpyParser.Single_subscript_attribute_targetContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.t_primary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterT_primary([NotNull] RenpyParser.T_primaryContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.t_primary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitT_primary([NotNull] RenpyParser.T_primaryContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.genexp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGenexp([NotNull] RenpyParser.GenexpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.genexp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGenexp([NotNull] RenpyParser.GenexpContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.arguments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArguments([NotNull] RenpyParser.ArgumentsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.arguments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArguments([NotNull] RenpyParser.ArgumentsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.args"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArgs([NotNull] RenpyParser.ArgsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.args"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArgs([NotNull] RenpyParser.ArgsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.kwargs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterKwargs([NotNull] RenpyParser.KwargsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.kwargs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitKwargs([NotNull] RenpyParser.KwargsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.starred_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStarred_expression([NotNull] RenpyParser.Starred_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.starred_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStarred_expression([NotNull] RenpyParser.Starred_expressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.kwarg_or_double_starred"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterKwarg_or_double_starred([NotNull] RenpyParser.Kwarg_or_double_starredContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.kwarg_or_double_starred"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitKwarg_or_double_starred([NotNull] RenpyParser.Kwarg_or_double_starredContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.kwarg_or_starred"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterKwarg_or_starred([NotNull] RenpyParser.Kwarg_or_starredContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.kwarg_or_starred"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitKwarg_or_starred([NotNull] RenpyParser.Kwarg_or_starredContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.slices"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSlices([NotNull] RenpyParser.SlicesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.slices"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSlices([NotNull] RenpyParser.SlicesContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.star_named_expressions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStar_named_expressions([NotNull] RenpyParser.Star_named_expressionsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.star_named_expressions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStar_named_expressions([NotNull] RenpyParser.Star_named_expressionsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.star_named_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStar_named_expression([NotNull] RenpyParser.Star_named_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.star_named_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStar_named_expression([NotNull] RenpyParser.Star_named_expressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.assignment_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignment_expression([NotNull] RenpyParser.Assignment_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.assignment_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignment_expression([NotNull] RenpyParser.Assignment_expressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RenpyParser.named_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNamed_expression([NotNull] RenpyParser.Named_expressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RenpyParser.named_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNamed_expression([NotNull] RenpyParser.Named_expressionContext context);
}
