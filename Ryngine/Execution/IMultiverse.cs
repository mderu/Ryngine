using Newtonsoft.Json.Linq;
using Ryngine.DataStructures;

namespace Ryngine.Execution;

public interface IMultiverse
{
    IDict<string, Snapshot> AllSaves { get; }
    JObject PersistentData { get; set; }
    Snapshot CurrentSave { get; set; }
    IDict<UndoRecordId, UndoRecord> UndoRecords { get; }
}
