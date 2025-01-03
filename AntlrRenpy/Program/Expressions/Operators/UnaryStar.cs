﻿using RynVM.Instructions;
using RynVM.Instructions.Expressions;
using RynVM.Script;

namespace AntlrRenpy.Program.Expressions.Operators;

/// <summary>
/// Expands the elements of an iterable into the parent iterable.
/// </summary>
public record class UnaryStar(IExpression InnerExpression) : IAtomic
{
    IAtomic IExpression.EvaluateValue(Store<string, IAtomic> store)
    {
        // The container (args, list definition, etc) needs to handle unpacking the values.
        return new UnaryStar(InnerExpression.EvaluateValue(store));
    }
}
