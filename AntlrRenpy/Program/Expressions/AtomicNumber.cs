namespace AntlrRenpy.Program.Expressions;

/// <summary>
/// Stored as a string to avoid floating representation of
/// incredibly high integers. Can be solved when the VM is
/// fleshed out.
/// </summary>
public record class AtomicNumber(string Value) : Atomic(Value)
{
    public override AtomicType Type
    {
        get
        {
            int dotIndex = Value.IndexOf('.');
            if (dotIndex < 0 || dotIndex == Value.Length - 1)
            {
                return AtomicType.Int;
            }
            else
            {
                return AtomicType.Float;
            }
        }
    }
}
