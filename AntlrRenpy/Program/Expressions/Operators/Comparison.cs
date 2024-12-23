namespace AntlrRenpy.Program.Expressions.Operators
{
    public record class Comparison(IExpression Lhs, Comparison.Type ComparisonType, IExpression Rhs) : IExpression
    {
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
}
