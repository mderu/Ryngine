namespace Ryngine.Instructions
{
    public enum OpCode
    {
        // Idempotent operations, typically used in expressions.
        NoOp,
        Add,
        Multiply,
        Negate,
        Clamp,


        // OpCodes for editing keys
        SetKey = 0x8000,
        RemoveKey,

        // OpCodes for editing lists
        Append,
        Insert,
        Remove,
        Clear,
    }
}
