using Newtonsoft.Json;
using Ryngine.Execution;
using Ryngine.Instructions;
using Ryngine.Instructions.Operations;

namespace Ryngine
{
    public class Executor
    {
        public Executor() { }

        public Snapshot Execute(Line line, Multiverse multiverse, Snapshot snapshot)
        {
            Operation op = line.Instruction.OpCode switch
            {
                OpCode.NoOp => new NoOp(),
                OpCode.SetKey => new SetKey(),

                _ => throw new System.Exception(
                    $"Unsupported instruction {JsonConvert.SerializeObject(line.Instruction)}")
            };

            op.Do(line, multiverse, snapshot);

            return snapshot;
        }
    }
}