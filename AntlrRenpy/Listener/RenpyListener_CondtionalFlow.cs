using Antlr4.Runtime.Misc;
using AntlrRenpy.Program.ControlFlows;

namespace AntlrRenpy.Listener;

public partial class RenpyListener : RenpyParserBaseListener
{
    private readonly Stack<Else> elseStack = [];

    public override void EnterIf_stmt([NotNull] RenpyParser.If_stmtContext context)
    {
        EnterIf();
    }

    public override void ExitIf_stmt([NotNull] RenpyParser.If_stmtContext context)
    {
        Else? elseStatement = null;
        if ((context.elif_stmt() is not null) || (context.else_block() is not null))
        {
            elseStatement = elseStack.Pop();
        }

        ExitIf(elseStatement);
    }

    public override void EnterElif_stmt([NotNull] RenpyParser.Elif_stmtContext context)
    {
        // Always treat elif as else { if (cond) ... }
        EnterElse();
        EnterIf();
    }

    public override void ExitElif_stmt([NotNull] RenpyParser.Elif_stmtContext context)
    {
        Else? elseStatement = null;
        if ((context.elif_stmt() is not null) || (context.else_block() is not null))
        {
            elseStatement = elseStack.Pop();
        }

        ExitIf(elseStatement);
        ExitElse();
    }

    public override void EnterElse_block([NotNull] RenpyParser.Else_blockContext context)
    {
        EnterElse();
    }

    public override void ExitElse_block([NotNull] RenpyParser.Else_blockContext context)
    {
        ExitElse();
    }

    public override void EnterWhile_stmt([NotNull] RenpyParser.While_stmtContext context)
    {
        blockStack.Push(new([]));
    }

    public override void ExitWhile_stmt([NotNull] RenpyParser.While_stmtContext context)
    {
        Else? elseStatement = null;
        if (context.else_block() is not null)
        {
            elseStatement = elseStack.Pop();
        }

        AppendInstruction(new While(blockStack.Pop(), expressionStack.Pop(), elseStatement));
    }

    private void EnterIf()
    {
        // Create a block for the if.
        blockStack.Push(new([]));
    }

    private void ExitIf(Else? elseStatement)
    {
        If ifStatement = new(blockStack.Pop(), expressionStack.Pop(), elseStatement);
        AppendInstruction(ifStatement);
    }

    private void EnterElse()
    {
        blockStack.Push(new([]));
    }

    private void ExitElse()
    {
        elseStack.Push(new(blockStack.Pop()));
    }
}
