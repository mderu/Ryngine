using Newtonsoft.Json.Linq;
using Ryngine.Execution;
using Ryngine.Utils;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Ryngine.Instructions;

public static class Reference
{
    // TODO: Maybe make this an @ instead?
    public const string PersistentPrefix = "persistent.";

    public static JToken Resolve(string variableReferencePath, IMultiverse multiverse, Snapshot snapshot)
    {
        if (!TryResolve(variableReferencePath, multiverse, snapshot, out JToken? jToken))
        {
            throw new MissingFieldException(
                $"Attempted to read {variableReferencePath}, but the value is unset.");
        }
        return jToken;
    }

    public static JToken? ResolveOrDefault(string variableReferencePath, IMultiverse multiverse, Snapshot snapshot)
    {
        TryResolve(variableReferencePath, multiverse, snapshot, out JToken? jToken);
        return jToken;
    }

    public static bool TryResolve(string variableReferencePath, IMultiverse multiverse, Snapshot snapshot, [NotNullWhen(true)] out JToken? jToken)
    {
        JObject dataStore = GetDataStore(variableReferencePath, multiverse, snapshot);
        string refPath = PurgePersistentPrefix(variableReferencePath);

        jToken = dataStore.SelectToken(refPath);
        return jToken is not null;
    }

    public static T Resolve<T>(string variableReferencePath, IMultiverse multiverse, Snapshot snapshot)
    {
        JToken jToken = Resolve(variableReferencePath, multiverse, snapshot);
        T? ret = jToken.Value<T>();

        return ret is null
            ? throw new InvalidCastException(
                $"Attempted to read {variableReferencePath} as {typeof(T).Name}, but the " +
                $"value is serialized as {jToken.Type}.")
            : ret;
    }

    /// <summary>
    /// Returns the JObject the variable is referring to, either PersistentData, or RunData.
    /// </summary>
    public static JObject GetDataStore(string variableReferencePath, IMultiverse multiverse, Snapshot snapshot)
    {
        if (variableReferencePath.StartsWith(PersistentPrefix))
        {
            return multiverse.PersistentData;
        }
        return snapshot.RunData;
    }


    public static string PurgePersistentPrefix(string variableReferencePath)
    {
        return variableReferencePath.TrimPrefix(PersistentPrefix);
    }
}
