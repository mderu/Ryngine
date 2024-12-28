using RynVM.Instructions;
using RynVM.Instructions.Expressions;
using RynVM.Script;
using System.Collections.Generic;

namespace AntlrRenpy.Program;

public class Parameters(
    IEnumerable<string> paramNames,
    Dictionary<string, IExpression> defaultValues,
    int numPositionalOnlyParams,
    int numNameOnlyParams) : IAtomic
{
    /// <summary>
    /// The list of parameter names in the order they appear in the function signature.
    /// </summary>
    public IEnumerable<string> ParamNames { get; } = paramNames;

    /// <summary>
    /// The expressions corresponding to the given parameter names.
    /// </summary>
    public Dictionary<string, IExpression> DefaultValues { get; } = defaultValues;

    /// <summary>
    /// The number of positional-only arguments. The first <see cref="NumPositionalOnlyParams"/> in
    /// <see cref="ParamNames"/> are the names of the positional-only parameters.
    /// </summary>
    public int NumPositionalOnlyParams { get; } = numPositionalOnlyParams;

    /// <summary>
    /// The number of name-only arguments. The last <see cref="NumNameOnlyParams"/> in
    /// <see cref="ParamNames"/> are be the names of the name-only parameters.
    /// </summary>
    public int NumNameOnlyParams { get; } = numNameOnlyParams;

    public override bool Equals(object? obj)
    {
        return obj is Parameters other
            && other.ParamNames.SequenceEqual(ParamNames)
            && other.DefaultValues.OrderBy(kvp => kvp.Key).SequenceEqual(DefaultValues.OrderBy(kvp => kvp.Key))
            && other.NumPositionalOnlyParams == NumPositionalOnlyParams
            && other.NumNameOnlyParams == NumNameOnlyParams;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ParamNames, DefaultValues, NumPositionalOnlyParams, NumNameOnlyParams);
    }

    IAtomic IExpression.EvaluateValue(Store<string, IAtomic> store)
    {
        Dictionary<string, IExpression> evaluatedDefaultValues = [];

        foreach ((string key, IExpression expression) in DefaultValues)
        {
            evaluatedDefaultValues[key] = expression.EvaluateValue(store);
        }

        return new Parameters(ParamNames, evaluatedDefaultValues, NumPositionalOnlyParams, NumNameOnlyParams);
    }
}
