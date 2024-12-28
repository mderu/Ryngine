using RynVM.Instructions;
using RynVM.Instructions.Expressions;

namespace AntlrRenpy.Program.Expressions.Operators;

/// <summary>
/// Expands the <see cref="InnerExpression"/>'s dictionary elements into the parent's kwargs.
/// </summary>
public record class UnaryDoubleStar(IExpression InnerExpression) : IAtomic
{
    IAtomic IExpression.EvaluateValue()
    {
        // The container (args, dict definition, etc) needs to handle unpacking the values.
        return new UnaryDoubleStar(InnerExpression.EvaluateValue());
    }
}
