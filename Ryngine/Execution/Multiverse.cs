using Newtonsoft.Json.Linq;
using Ryngine.DataStructures;

namespace Ryngine.Execution;

/// <summary>
/// A simple implementation of IMultiverse that avoids long-term save implementations.
/// </summary>
public class Multiverse : IMultiverse
{
    public JObject PersistentData { get; set; } = [];

    public Snapshot CurrentSave { get; set; } = new(UndoRecord.RootRecord);

    /// <summary>
    /// A dictionary of UndoRecord.Hash to its value.
    /// </summary>
    public IDict<UndoRecordId, UndoRecord> UndoRecords { get; set; }
        = new Dict<UndoRecordId, UndoRecord>();

    public IDict<string, Snapshot> AllSaves { get; set; }
        = new Dict<string, Snapshot>();
}
