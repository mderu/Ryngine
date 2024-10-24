using Newtonsoft.Json.Linq;
using Ryngine.Execution;
using System;

namespace Ryngine.Instructions.Operations
{
    public abstract class Operation
    {
        public abstract JToken Do(Line line, Multiverse multiverse, Snapshot snapshot);
        public abstract JToken Undo(Multiverse multiverse, Snapshot snapshot);
    }

    public abstract class Operation<Args, UndoPacket> : Operation
    {
        public override JToken Do(Line line, Multiverse multiverse, Snapshot snapshot)
        {
            Args? t = line.Instruction.Args.ToObject<Args>();
            return t is null
                ? throw new Exception("Instruction's data is null. Should I allow this to happen?")
                : Do(line, t, multiverse, snapshot);
        }

        public override JToken Undo(Multiverse multiverse, Snapshot snapshot)
        {
            UndoPacket? up = snapshot.UndoRecord.UndoPacket.ToObject<UndoPacket>();
            return up is null 
                ? throw new Exception("The undo packet is null. Please use JObject.CreateNull() instead.")
                : Undo(up, multiverse, snapshot);
        }

        public abstract JToken Do(Line line, Args arguments, Multiverse multiverse, Snapshot snapshot);
        public abstract JToken Undo(UndoPacket undoPacket, Multiverse multiverse, Snapshot snapshot);
    }
}
