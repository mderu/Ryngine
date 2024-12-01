using Antlr4.Runtime.Misc;
using AntlrRenpy.Program;
using AntlrRenpy.Program.Instructions;
using static RenpyParser;

namespace AntlrRenpy
{
    public class RenpyListener : RenpyParserBaseListener
    {
        public Script Script { get; private init; } = new();

        public override void EnterEntire_tree([NotNull] RenpyParser.Entire_treeContext context)
        {
            base.EnterEntire_tree(context);
        }

        public override void EnterStatement([NotNull] RenpyParser.StatementContext context)
        {
            base.EnterStatement(context);
        }

        public override void EnterPass_statement([NotNull] RenpyParser.Pass_statementContext context)
        {
            Script.AppendInstruction(new Pass());
            base.EnterPass_statement(context);
        }

        public override void EnterReturn_simple([NotNull] RenpyParser.Return_simpleContext context)
        {
            Script.AppendInstruction(new ReturnSimple());
            base.EnterReturn_simple(context);
        }

        public override void EnterJump_constant([NotNull] RenpyParser.Jump_constantContext context)
        {
            Script.AppendInstruction(new JumpConstant(context.LABEL_NAME().GetText()));
            base.EnterJump_constant(context);
        }

        public override void EnterCall_constant([NotNull] RenpyParser.Call_constantContext context)
        {
            Script.AppendInstruction(new CallConstant(context.LABEL_NAME().GetText()));
            base.EnterCall_constant(context);
        }

        public override void EnterLabel_constant([NotNull] RenpyParser.Label_constantContext context)
        {
            Script.InsertLabel(context.LABEL_NAME().GetText());
            base.EnterLabel_constant(context);
        }

        //public override void EnterSay([NotNull] RenpyParser.SayContext context)
        //{
        //    string text = context.STRING().GetText();
        //    string speaker = context.NAME().GetText();

        //    Script.AppendInstruction(
        //        new Say(text)
        //        {
        //            Speaker = speaker,
        //        }
        //    );
        //    base.EnterSay(context);
        //}
    }
}
