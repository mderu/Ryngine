using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Instructions;

public record class Assignment(IExpression Lhs, Assignment.Type AssignmentType, IExpression Rhs) : IInstruction
{
    public enum Type
    {
        Equal,
        PlusEqual,
        MinEqual,
        StarEqual,
        SlashEqual,
        PercentEqual,
        AmperEqual,
        VbarEqual,
        CircumflexEqual,
        LeftShiftEqual,
        RightShiftEqual,
        DoubleStarEqual,
        DoubleSlashEqual,
    }
}
