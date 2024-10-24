using Newtonsoft.Json.Linq;
using Ryngine.Execution;
using Ryngine.Instructions;
using Ryngine.Instructions.Operations;
using Ryngine.Utils;

namespace Ryngine.Test
{
    public class SetKeyTests
    {
        [Fact]
        public void Do_SetsRunData()
        {
            var snapshot = new Snapshot(UndoRecord.RootRecord, "");
            var multiverse = new Multiverse();
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

            new SetKey().Do(line, multiverse, snapshot);

            Assert.Single(snapshot.RunData);
            Assert.True(snapshot.RunData.ContainsKey("a"));
            Assert.Equal(1, snapshot.RunData["a"]);
        }

        [Fact]
        public void Do_WhenRevertingANonExistentValue_SetsPreviousValueToNull()
        {
            var snapshot = new Snapshot(UndoRecord.RootRecord, "");
            var multiverse = new Multiverse();
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

            new SetKey().Do(line, multiverse, snapshot);

            var undoPacket = snapshot
                .UndoRecord
                .UndoPacket
                // Forgiveness: if this fails, fix it.
                .ToObject<SetKey.UndoPacket>(ConversionUtils.JsonSerializer)!;
            Assert.Null(undoPacket.PreviousValue);
        }

        [Fact]
        public void Do_WhenRevertingAValue_SetsPreviousValue()
        {
            var snapshot = new Snapshot(
                UndoRecord.RootRecord,
                "",
                JObject.Parse($$"""{"a": 0}"""));
            var multiverse = new Multiverse();
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

            new SetKey().Do(line, multiverse, snapshot);

            var expectedValue = new JValue(0);
            var undoPacket = snapshot
                .UndoRecord
                .UndoPacket
                // Forgiveness: if this fails, fix it.
                .ToObject<SetKey.UndoPacket>()!;
            
            Assert.NotNull(undoPacket.PreviousValue);
            Assert.Equal(expectedValue.Type, undoPacket.PreviousValue.Type);
            Assert.Equal(expectedValue.Value<int>(), undoPacket.PreviousValue.Value<int>());
        }
    }
}
