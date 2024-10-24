using Newtonsoft.Json.Linq;
using Ryngine.Instructions;
using System;
using System.Collections.Generic;

namespace Ryngine.Execution
{
    public class Multiverse
    {
        public JObject PersistentData { get; init; } = [];
        public Dictionary<ProgramCounter, Instruction> Instructions { get; set; } = [];
        public Dictionary<ProgramCounter, ProgramCounter> NextInstruction { get; set; } = [];
        public Dictionary<ProgramCounter, ProgramCounter> PreviousInstruction { get; set; } = [];

        /// <summary>
        /// A dictionary of UndoRecord.Hash to its value.
        /// </summary>
        public Dictionary<Int128, UndoRecord> UndoRecords { get; set; } = [];
        public Dictionary<string, Snapshot> AllSaves { get; set; } = [];
    }
}
