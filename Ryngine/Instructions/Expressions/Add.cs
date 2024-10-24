using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ryngine.Execution;
using Ryngine.Instructions.Operations;
using System.Collections.Generic;
using System.Linq;

namespace Ryngine.Instructions.Expressions
{
    //public class Add : Operation<Add.AddArgs>
    //{
    //    public class AddArgs
    //    {
    //        [JsonProperty]
    //        public List<string> Operands { get; set; } = [];

    //        [JsonProperty]
    //        public List<float> Constants { get; set; } = [];
    //    }

    //    public override JToken Do(AddArgs args, Multiverse multiverse, Snapshot snapshot)
    //    {
    //        Snapshot reflessSnapshot = snapshot;
    //        return args.Constants.Sum()
    //            + args.Operands
    //                .Select(operand => Reference.Resolve<float>(operand, multiverse, reflessSnapshot))
    //                .Sum();
    //    }

    //    public override JToken Undo(AddArgs args, Multiverse multiverse, Snapshot snapshot)
    //    {
    //        // Add operations do not have anything to undo, because memory is not being set.
    //        return JValue.CreateNull();
    //    }
    //}
}
