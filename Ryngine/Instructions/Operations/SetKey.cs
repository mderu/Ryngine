using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ryngine.Execution;
using Ryngine.Utils;
using System;
using System.IO.Hashing;
using System.Text;

namespace Ryngine.Instructions.Operations
{
    public class SetKey() : Operation<SetKey.Args, SetKey.UndoPacket>
    {
        public record Args
        {
            [JsonProperty]
            public string VarName { get; set; } = "";

            [JsonProperty]
            public JToken Value { get; set; } = JValue.CreateNull();
        }

        public record UndoPacket
        {
            [JsonProperty]
            public required string VarName { get; set; }
            /// <summary>
            /// The previous value, or null if the value did not exist.
            /// </summary>
            [JsonProperty]
            public required JToken? PreviousValue { get; init; }
        }

        public override JToken Do(Line line, Args args, Multiverse multiverse, Snapshot snapshot)
        {
            JToken? oldValue = Reference.ResolveOrDefault(args.VarName, multiverse, snapshot);
            JObject dataStore = Reference.GetDataStore(args.VarName, multiverse, snapshot);

            Int128 newUndoHash = XxHash128.Hash([
                // TODO: Avoid toString'ing every time.
                // We pick RunData over dataStore because persistence should never affect the hash.
                // Undo's on PersistentData are ignored.
                .. Encoding.UTF8.GetBytes(snapshot.RunData.ToString()),
                .. Encoding.UTF8.GetBytes(line.ProgramCounter),
                .. snapshot.UndoRecord.Hash.ToBytes(),
            ]).ToInt128();

            UndoPacket newUndoPacket = new()
            {
                VarName = args.VarName,
                PreviousValue = oldValue,
            };

            UndoRecord newUndoRecord = new(
                programCounter: line.ProgramCounter,
                previousUndoRecordId: snapshot.UndoRecord.Hash,
                currentUndoRecordId: newUndoHash,
                undoPacket: newUndoPacket.ToJObject());

            multiverse.UndoRecords.Add(newUndoHash, newUndoRecord);

            snapshot.ProgramCounter = line.ProgramCounter;
            snapshot.UndoRecord = newUndoRecord;
            dataStore[args.VarName] = args.Value;

            return JValue.CreateNull();
        }

        public override JToken Undo(UndoPacket undoPacket, Multiverse multiverse, Snapshot snapshot)
        {
            JObject dataStore = Reference.GetDataStore(undoPacket.VarName, multiverse, snapshot);
            if (dataStore == multiverse.PersistentData)
            {
                return JValue.CreateNull();
            }

            string refPath = Reference.PurgePersistentPrefix(undoPacket.VarName);

            if (undoPacket.PreviousValue is null)
            {
                snapshot.RunData.Remove(refPath);
            }
            else
            {
                snapshot.RunData[refPath] = undoPacket.PreviousValue;
            }

            return JValue.CreateNull();
        }
    }
}
