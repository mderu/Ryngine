using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ryngine.Instructions
{
    public record Instruction
    {
        [JsonProperty]
        public OpCode OpCode { get; init; } = OpCode.NoOp;

        [JsonProperty]
        public JObject Args { get; init; } = [];
    }
}
