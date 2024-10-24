using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Ryngine.Execution
{
    public class UndoRecord(
        ProgramCounter programCounter,
        Int128 previousUndoRecordId,
        Int128 currentUndoRecordId,
        JObject undoPacket)
    {
        public static UndoRecord RootRecord => new("", 0, 0, []);

        public ProgramCounter ProgramCounter { get; } = programCounter;

        // TODO: We can probably get away with using 64 bit hashes instead.
        //       For 64 bits, birthday paradox puts 50% chance at ~2^32.
        public Int128 PreviousUndoRecordId { get; } = previousUndoRecordId;
        public Int128 Hash { get; } = currentUndoRecordId;
        public JObject UndoPacket { get; set; } = undoPacket;
    }
}
