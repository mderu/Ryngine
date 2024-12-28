namespace AntlrRenpy.Program.Expressions;

public record class Null() : Atomic(InnerValue: null)
{
    public override AtomicType Type => AtomicType.Null;
}
