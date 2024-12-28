using RynVM.Instructions.Expressions;

namespace RynVM.Instructions
{
    /// <summary>
    /// An atomic is an expression that cannot be further reduced.
    /// </summary>
    public interface IAtomic : IExpression
    {
    }
}
