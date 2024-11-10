using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ryngine.Execution;
using Ryngine.Instructions;
using Ryngine.Utils;
using System;

namespace Ryngine.Clients
{
    public class RynClient(Multiverse multiverse) : IRynClient
    {
        private Multiverse Multiverse { get; init; } = multiverse;

        public string GetState(string saveName)
        {
            return GetMemoryState(saveName);
        }

        public string ApplyDelta(string saveName, string delta)
        {
            PostDelta(saveName, delta);

            return GetMemoryState(saveName);
        }

        public void PostDelta(string saveName, string delta)
        {
            new SetKeys().Do(
                JsonConvert.DeserializeObject<Delta>(delta)
                    ?? throw new Exception("not valid JSON"),
                Multiverse,
                Multiverse.AllSaves[saveName]);
        }

        public string RequestUndo(string saveName)
        {
            new SetKeys().Undo(
                Multiverse.AllSaves[saveName].UndoRecord.UndoPacket,
                Multiverse,
                Multiverse.AllSaves[saveName]
            );

            return GetMemoryState(saveName);
        }

        public string SaveSnapshot(string currentSaveName, string savePrefix)
        {
            string newSaveName = savePrefix;
            while (Multiverse.AllSaves.ContainsKey(newSaveName))
            {
                newSaveName = savePrefix + Guid.NewGuid().ToString()[0..8];
            }

            Snapshot currentSnapshot = Multiverse.AllSaves[currentSaveName];
            Multiverse.AllSaves[newSaveName] = new Snapshot(
                currentSnapshot.UndoRecord,
                new JObject(currentSnapshot.RunData));

            return newSaveName;
        }
        
        public void LoadMultiverseFile(string filepath)
        {
            throw new System.NotImplementedException();
        }

        public void SaveMultiverseFile(string filepath)
        {
            throw new System.NotImplementedException();
        }

        private string GetMemoryState(string saveName)
        {
            return new JObject()
            {
                ["Persistent"] = Multiverse.PersistentData,
                ["RunData"] = Multiverse.AllSaves[saveName].RunData,
            }.ToJsonString();
        }
    }
}
