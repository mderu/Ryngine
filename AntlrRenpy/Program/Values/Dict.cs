using RynVM.Instructions;
using RynVM.Instructions.Expressions;
using RynVM.Script;

namespace AntlrRenpy.Program.Values;

public class Dict(IEnumerable<Expressions.KeyValuePair> kvps) : IAtomic
{
    public OrderedDictionary<IAtomic, IAtomic> Kvps { get; } = new(kvps
        .Select(kvp => new KeyValuePair<IAtomic, IAtomic>((IAtomic)kvp.Key, (IAtomic)kvp.Value)));

    IAtomic IExpression.EvaluateValue(Store<string, IAtomic> store)
    {
        throw new NotImplementedException();
    }
}
