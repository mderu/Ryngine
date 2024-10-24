using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Ryngine.Execution
{
    public class Snapshot(UndoRecord undoRecord, ProgramCounter programCounter, JObject? runData = null)
    {
        [JsonProperty]
        public JObject RunData { get; init; } = runData ?? [];

        [JsonProperty]
        public ProgramCounter ProgramCounter { get; set; } = programCounter;

        [JsonProperty]
        public UndoRecord UndoRecord { get; set; } = undoRecord;
    }
}
