using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ryngine.Execution;
using Ryngine.Instructions;
using Ryngine.Utils;
using System;

namespace Ryngine.Clients
{
    public class RynClient(IMultiverse multiverse) : IRynClient
    {
        private IMultiverse Multiverse { get; init; } = multiverse;

        public string GetState()
        {
            return GetCurrentMemoryState();
        }

        public void LoadState(string saveName)
        {
            Multiverse.CurrentSave = Multiverse.AllSaves[saveName];
        }

        public void SaveState(string saveName) 
        {
            Multiverse.AllSaves[saveName] = Multiverse.CurrentSave;
        }

        public string ApplyDelta(string delta)
        {
            PostDelta(delta);

            return GetCurrentMemoryState();
        }

        public void PostDelta(string delta)
        {
            new SetKeys().Do(
                JsonConvert.DeserializeObject<Delta>(delta)
                    ?? throw new Exception("not valid JSON"),
                Multiverse,
                Multiverse.CurrentSave);
        }

        public string RequestUndo()
        {
            new SetKeys().Undo(
                Multiverse.CurrentSave.UndoRecord.UndoPacket,
                Multiverse,
                Multiverse.CurrentSave
            );

            return GetCurrentMemoryState();
        }
        
        public void LoadMultiverse(string filepath)
        {
            throw new System.NotImplementedException();
        }

        public void SaveMultiverse(string filepath)
        {
            throw new System.NotImplementedException();
        }

        private string GetCurrentMemoryState()
        {
            return new JObject()
            {
                ["Persistent"] = Multiverse.PersistentData,
                ["RunData"] = Multiverse.CurrentSave.RunData,
            }.ToJsonString();
        }
    }
}
