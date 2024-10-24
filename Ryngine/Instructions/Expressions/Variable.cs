using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ryngine.Execution;
using Ryngine.Instructions.Operations;

namespace Ryngine.Instructions.Expressions
{
    //public class Variable : Operation<Variable.VariableArgs>
    //{
    //    public class VariableArgs
    //    {
    //        [JsonProperty]
    //        public string VariablePath { get; set; } = "";
    //    }

    //    public override JToken Do(VariableArgs args, Multiverse multiverse, Snapshot snapshot)
    //    {
    //        return Reference.Resolve(args.VariablePath, multiverse, snapshot);
    //    }

    //    public override JToken Undo(VariableArgs args, Multiverse multiverse, Snapshot snapshot)
    //    {
    //        return JValue.CreateNull();
    //    }
    //}
}
