using RynVM.Instructions;
using RynVM.Instructions.Expressions;
using RynVM.Script;

namespace AntlrRenpy.Program.Expressions.Operators;

public record class Comparison(IExpression Lhs, Comparison.Type ComparisonType, IExpression Rhs) : IExpression
{
    IAtomic IExpression.EvaluateValue(Store<string, IAtomic> store)
    {
        IAtomic lhsAtomic = Lhs.EvaluateValue(store);
        if (lhsAtomic is Null)
        {
            // Note: even though Python does not support comparisons with NoneType, rhs is still evaluated.
            string rhsType = ((Atomic)Rhs.EvaluateValue(store)).Type.GetName();
            throw new InvalidOperationException(
                $"TypeError: '<' not supported between instances of 'NoneType' and '{rhsType}'");
        }
        else if (lhsAtomic is AtomicNumber || lhsAtomic is Atomic<bool>)
        {
            // TODO: Real numerical checks
            decimal lhsParsed = lhsAtomic is AtomicNumber lhsNumber
                ? decimal.Parse(lhsNumber.Value)
                : lhsAtomic is Atomic<bool> lhsBool
                    ? (lhsBool.Value ? 1 : 0)
                    : throw new InvalidProgramException("Unreachable exception.");

            // TODO: Only perform these on equality checks, not `is` and `in` operators.
            IAtomic rhsAtomic = Rhs.EvaluateValue(store);
            decimal rhsParsed = rhsAtomic is AtomicNumber rhsNumber
                ? decimal.Parse(rhsNumber.Value)
                : rhsAtomic is Atomic<bool> rhsBool
                    ? (rhsBool.Value ? 1 : 0)
                    : throw new InvalidOperationException(
                        $"TypeError: '{ComparisonType}' not supported between instances of " +
                        $"'{lhsAtomic.GetType()}' and '{rhsAtomic.GetType()}'");

            bool returnValue = ComparisonType switch
            {
                Type.IsEqualTo => lhsParsed == rhsParsed,
                Type.IsNotEqualTo => lhsParsed != rhsParsed,
                Type.LessThanOrEqual => lhsParsed <= rhsParsed,
                Type.LessThan => lhsParsed < rhsParsed,
                Type.GreaterThanOrEqual => lhsParsed >= rhsParsed,
                Type.GreaterThan => lhsParsed > rhsParsed,
                Type.In =>
                    throw new NotImplementedException("In operator not implemented."),
                Type.NotIn =>
                    throw new NotImplementedException("In operator not implemented."),
                Type.Is =>
                    throw new NotImplementedException("Is operator not implemented."),
                Type.IsNot =>
                    throw new NotImplementedException("Is operator not implemented."),
                _ =>
                    throw new NotImplementedException($"Unable to compare {nameof(AtomicNumber)}s using {ComparisonType}")
            };
            return new Atomic<bool>(returnValue);
        }
        else if (lhsAtomic is Atomic<string> lhsString)
        {
            Atomic rhsAtomic = (Atomic)Rhs.EvaluateValue(store);

            if (rhsAtomic.Type != AtomicType.String)
            {
                throw new InvalidOperationException(
                    $"TypeError: '<' not supported between instances of 'str' and '{rhsAtomic.Type}'");
            }

            int compareValue = lhsString.Value.CompareTo(((Atomic<string>)rhsAtomic).Value);

            bool returnValue = ComparisonType switch
            {
                Type.IsEqualTo => compareValue == 0,
                Type.IsNotEqualTo => compareValue != 0,
                Type.LessThanOrEqual => compareValue <= 0,
                Type.LessThan => compareValue < 0,
                Type.GreaterThanOrEqual => compareValue >= 0,
                Type.GreaterThan => compareValue > 0,
                Type.In =>
                    throw new NotImplementedException("In operator not implemented."),
                Type.NotIn =>
                    throw new NotImplementedException("In operator not implemented."),
                Type.Is =>
                    throw new NotImplementedException("Is operator not implemented."),
                Type.IsNot =>
                    throw new NotImplementedException("Is operator not implemented."),
                _ =>
                    throw new NotImplementedException($"Unable to compare {nameof(AtomicNumber)}s using {ComparisonType}")
            };
            return new Atomic<bool>(returnValue);
        }
        else
        {
            throw new NotImplementedException($"Comparisons for {Lhs.GetType()} have not been implemented.");
        }
    }

    public enum Type
    {
        IsEqualTo,
        IsNotEqualTo,
        LessThanOrEqual,
        LessThan,
        GreaterThanOrEqual,
        GreaterThan,
        In,
        NotIn,
        Is,
        IsNot,
    }
}
