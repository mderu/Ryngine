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
	/// Visit a parse tree produced by <see cref="RenpyParser.python_one_line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPython_one_line([NotNull] RenpyParser.Python_one_lineContext context);
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
	/// Visit a parse tree produced by <see cref="RenpyParser.call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCall([NotNull] RenpyParser.CallContext context);
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
	/// Visit a parse tree produced by <see cref="RenpyParser.parameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameters([NotNull] RenpyParser.ParametersContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.kwds"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitKwds([NotNull] RenpyParser.KwdsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.param_no_default"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParam_no_default([NotNull] RenpyParser.Param_no_defaultContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.param_with_default"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParam_with_default([NotNull] RenpyParser.Param_with_defaultContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.param"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParam([NotNull] RenpyParser.ParamContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnnotation([NotNull] RenpyParser.AnnotationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.default_assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefault_assignment([NotNull] RenpyParser.Default_assignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.type_comment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType_comment([NotNull] RenpyParser.Type_commentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.if_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIf_stmt([NotNull] RenpyParser.If_stmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.elif_stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElif_stmt([NotNull] RenpyParser.Elif_stmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.else_block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElse_block([NotNull] RenpyParser.Else_blockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitList([NotNull] RenpyParser.ListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.tuple"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTuple([NotNull] RenpyParser.TupleContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.set"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSet([NotNull] RenpyParser.SetContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.dict"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDict([NotNull] RenpyParser.DictContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.double_starred_kvpairs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDouble_starred_kvpairs([NotNull] RenpyParser.Double_starred_kvpairsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.double_starred_kvpair"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDouble_starred_kvpair([NotNull] RenpyParser.Double_starred_kvpairContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.kvpair"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitKvpair([NotNull] RenpyParser.KvpairContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.star_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStar_expression([NotNull] RenpyParser.Star_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] RenpyParser.ExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.bitwise_or"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBitwise_or([NotNull] RenpyParser.Bitwise_orContext context);
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
	/// Visit a parse tree produced by <see cref="RenpyParser.single_target"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSingle_target([NotNull] RenpyParser.Single_targetContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.single_subscript_attribute_target"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSingle_subscript_attribute_target([NotNull] RenpyParser.Single_subscript_attribute_targetContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.t_primary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitT_primary([NotNull] RenpyParser.T_primaryContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.genexp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGenexp([NotNull] RenpyParser.GenexpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.arguments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArguments([NotNull] RenpyParser.ArgumentsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.args"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgs([NotNull] RenpyParser.ArgsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.kwargs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitKwargs([NotNull] RenpyParser.KwargsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.starred_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStarred_expression([NotNull] RenpyParser.Starred_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.kwarg_or_double_starred"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitKwarg_or_double_starred([NotNull] RenpyParser.Kwarg_or_double_starredContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.kwarg_or_starred"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitKwarg_or_starred([NotNull] RenpyParser.Kwarg_or_starredContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.slices"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSlices([NotNull] RenpyParser.SlicesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.star_named_expressions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStar_named_expressions([NotNull] RenpyParser.Star_named_expressionsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.star_named_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStar_named_expression([NotNull] RenpyParser.Star_named_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.assignment_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment_expression([NotNull] RenpyParser.Assignment_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RenpyParser.named_expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNamed_expression([NotNull] RenpyParser.Named_expressionContext context);
}
