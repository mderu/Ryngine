using Newtonsoft.Json.Linq;
using Ryngine.Execution;

namespace Ryngine.Instructions.Operations
{
    public class NoOp : Operation
    {
        public override JToken Do(Line line, Multiverse multiverse, Snapshot snapshot)
        {
            return JValue.CreateNull();
        }

        public override JToken Undo(Multiverse multiverse, Snapshot snapshot)
        {
            return JValue.CreateNull();
        }
    }
}
