using Ryngine.Execution;
using Ryngine.Instructions;
using Ryngine.Instructions.Operations;
using Ryngine.Utils;
using System.Diagnostics;

namespace Ryngine.Test
{
    public class ExecutorTests
    {
        [Fact]
        public void Execute_UpdatesTheProgramCounter()
        {
            var snapshot = new Snapshot(UndoRecord.RootRecord, "");
            var multiverse = new Multiverse();
            var executor = new Executor();

            Line line = new()
            {
                Instruction = new()
                {
                    OpCode = OpCode.SetKey,
                    Args = new SetKey.Args()
                    {
                        VarName = "a",
                        Value = 1,
                    }.ToJObject(),
                },
                ProgramCounter = "LOC_A",
            };

            executor.Execute(line, multiverse, snapshot);

            // Value is set.
            Assert.Single(snapshot.RunData);
            Assert.True(snapshot.RunData.ContainsKey("a"));
            Assert.Equal(1, snapshot.RunData["a"]);

            // Program Counter is updated
            Assert.Equal("LOC_A", snapshot.ProgramCounter);
        }
    }
}