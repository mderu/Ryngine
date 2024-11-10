using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Ryngine.Execution
{
    public class Multiverse
    {
        public JObject PersistentData { get; init; } = [];

        /// <summary>
        /// A dictionary of UndoRecord.Hash to its value.
        /// </summary>
        public Dictionary<Int128, UndoRecord> UndoRecords { get; set; } = [];
        public Dictionary<string, Snapshot> AllSaves { get; set; } = [];
    }
}
