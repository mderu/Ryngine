using Newtonsoft.Json.Linq;
using Ryngine.Execution;
using Ryngine.Utils;
using System;
using System.IO.Hashing;
using System.Text;

namespace Ryngine.Instructions
{
    public class SetKeys()
    {
        public void Do(Delta delta, Multiverse multiverse, Snapshot snapshot)
        {
            UndoPacket oldValues = [];
            foreach (var kvp in delta)
            {
                // Store old value
                JToken? oldValue = Reference.ResolveOrDefault(kvp.Key, multiverse, snapshot);
                oldValues.Add(kvp.Key, oldValue);

                // Write new value.
                JObject dataStore = Reference.GetDataStore(kvp.Key, multiverse, snapshot);
                dataStore[kvp.Key] = kvp.Value;
            }

            // TODO: Use a 64-bit width to match UndoRecordId size.
            UndoRecordId newUndoHash = BitConverter.ToInt64(
                XxHash128.Hash([
                    // TODO: Avoid toString'ing every time.
                    // We pick RunData over dataStore because persistence should never affect the hash.
                    // Undo's on PersistentData are ignored.
                    .. Encoding.UTF8.GetBytes(snapshot.RunData.ToString()),
                    .. BitConverter.GetBytes(snapshot.UndoRecord.Hash)
                ]).AsSpan(0, 16)
            );

            UndoRecord newUndoRecord = new(
                previousUndoRecordId: snapshot.UndoRecord.Hash,
                currentUndoRecordId: newUndoHash,
                undoPacket: oldValues
            );

            multiverse.UndoRecords.Add(newUndoHash, newUndoRecord);
            snapshot.UndoRecord = newUndoRecord;
        }

        public void Undo(UndoPacket undoPacket, Multiverse multiverse, Snapshot snapshot)
        {
            foreach (var kvp in undoPacket)
            {
                JObject dataStore = Reference.GetDataStore(kvp.Key, multiverse, snapshot);

                if (dataStore == multiverse.PersistentData)
                {
                    continue;
                }

                string refPath = Reference.PurgePersistentPrefix(kvp.Key);

                if (kvp.Value is null)
                {
                    snapshot.RunData.Remove(refPath);
                }
                else
                {
                    snapshot.RunData[refPath] = kvp.Value;
                }
            }
        }
    }
}
