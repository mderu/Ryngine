using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ryngine.Execution;
using Ryngine.Utils;
using System;
using System.IO.Hashing;
using System.Text;

namespace Ryngine.Instructions.Operations
{
    public class SetKeys() : Operation<SetKeys.Args, SetKeys.UndoPacket>
    {
        public record Args
        {
            public required JObject NewValues { get; init; }
        }

        public record UndoPacket
        {
            /// <summary>
            /// The previous value, or null if the value did not exist.
            /// </summary>
            [JsonProperty]
            public required JObject PreviousValues { get; init; }
        }

        public override JToken Do(Line line, Args args, Multiverse multiverse, Snapshot snapshot)
        {
            JObject oldValues = [];
            foreach (var kvp in args.NewValues)
            {
                // Store old value
                JToken? oldValue = Reference.ResolveOrDefault(kvp.Key, multiverse, snapshot);
                oldValues.Add(kvp.Key, oldValue);

                // Write new value.
                JObject dataStore = Reference.GetDataStore(kvp.Key, multiverse, snapshot);
                dataStore[kvp.Key] = kvp.Value;
            }

            Int128 newUndoHash = XxHash128.Hash([
                // TODO: Avoid toString'ing every time.
                // We pick RunData over dataStore because persistence should never affect the hash.
                // Undo's on PersistentData are ignored.
                .. Encoding.UTF8.GetBytes(snapshot.RunData.ToString()),
                .. Encoding.UTF8.GetBytes(line.ProgramCounter),
                .. snapshot.UndoRecord.Hash.ToBytes(),
            ]).ToInt128();

            UndoRecord newUndoRecord = new(
                programCounter: snapshot.ProgramCounter,
                previousUndoRecordId: snapshot.UndoRecord.Hash,
                currentUndoRecordId: newUndoHash,
                undoPacket: new UndoPacket() { PreviousValues = oldValues }.ToJObject());

            multiverse.UndoRecords.Add(newUndoHash, newUndoRecord);

            snapshot.ProgramCounter = line.ProgramCounter;
            snapshot.UndoRecord = newUndoRecord;

            return JValue.CreateNull();
        }

        public override JToken Undo(UndoPacket undoPacket, Multiverse multiverse, Snapshot snapshot)
        {
            foreach (var kvp in undoPacket.PreviousValues)
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

            snapshot.ProgramCounter = snapshot.UndoRecord.ProgramCounter;

            return JValue.CreateNull();
        }
    }
}
