using Newtonsoft.Json.Linq;
using Ryngine.Execution;
using Ryngine.Instructions;

namespace Ryngine.Test
{
    public class SetKeysTests
    {
        [Fact]
        public void Do_SetsRunData()
        {
            var snapshot = new Snapshot(UndoRecord.RootRecord);
            var multiverse = new Multiverse();
            Delta delta = new()
            {
                ["a"] = 1,
            };

            new SetKeys().Do(delta, multiverse, snapshot);

            Assert.Single(snapshot.RunData);
            Assert.True(snapshot.RunData.ContainsKey("a"));
            Assert.Equal(1, snapshot.RunData["a"]);
        }

        [Fact]
        public void Do_WhenRevertingANonExistentValue_SetsPreviousValueToNull()
        {
            var snapshot = new Snapshot(UndoRecord.RootRecord);
            var multiverse = new Multiverse();
            Delta delta = new()
            {
                ["a"] = 1,
            };

            new SetKeys().Do(delta, multiverse, snapshot);

            var undoPacket = snapshot
                .UndoRecord
                .UndoPacket;
            Assert.Equal(JValue.CreateNull(), undoPacket["a"]);
        }

        [Fact]
        public void Do_WhenRevertingAValue_SetsPreviousValue()
        {
            var snapshot = new Snapshot(
                UndoRecord.RootRecord,
                JObject.Parse($$"""{"a": 0}"""));
            var multiverse = new Multiverse();
            Delta delta = new()
            {
                ["a"] = 1,
            };

            new SetKeys().Do(delta, multiverse, snapshot);

            var expectedValue = new JValue(0);
            var undoPacket = snapshot
                .UndoRecord
                .UndoPacket;
            
            Assert.NotNull(undoPacket["a"]);
            Assert.Equal(expectedValue.Type, undoPacket["a"]!.Type);
            Assert.Equal(expectedValue.Value<int>(), undoPacket["a"]!.Value<int>());
        }
    }
}
