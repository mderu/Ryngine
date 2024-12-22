namespace AntlrRenpy.Program.Expressions
{
    /// <summary>
    /// Stored as a string to avoid floating representation of
    /// incredibly high integers. Can be solved when the VM is
    /// fleshed out.
    /// </summary>
    public record class ConstantNumber(string value) : Constant<string>(value)
    {
    }
}
