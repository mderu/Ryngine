using Microsoft.Data.Sqlite;
using Ryngine.Clients;
using Ryngine.Execution;

namespace Ryngine.Test.EndToEndTests
{
    public class WriteDeltasTests : IDisposable
    {
        private static readonly string TempDirectory = Path.Combine(Path.GetTempPath(), nameof(WriteDeltasTests));
        
        public WriteDeltasTests()
        {
            if (Directory.Exists(TempDirectory))
            {
                Directory.Delete(TempDirectory, true);
            }
            Directory.CreateDirectory(TempDirectory);
        }

        public void Dispose()
        {
            //GC.SuppressFinalize(this);
            //Directory.Delete(TempDirectory, true);
        }

        [Fact]
        public void WriteDeltas_DoesWhatItShould()
        {
            int totalNumberOfIterations = 2000;
            string saveName = "newSave";
            string connectionString = $"Data Source=\"{TempDirectory}/test.db\"";

            using SqliteConnection connection = new(connectionString);

            IMultiverse multiverse = new SqliteMultiverse(connection);
            RynClient rynClient = new(multiverse);

            var result = rynClient.ApplyDelta(saveName, """
                {
                    "dialogueTitle": "Narrator", 
                    "textBox": "First Message!",
                }
            """);

            Assert.Equal(
                """{"Persistent":{},"RunData":{"dialogueTitle":"Narrator","textBox":"First Message!"}}""",
                result);

            for (int i = 0; i < totalNumberOfIterations; i++)
            {
                rynClient.PostDelta(saveName, $$"""{"textBox": "{{i}}"}""");
            }

            result = rynClient.GetState(saveName);

            Assert.Equal(
                $$$"""{"Persistent":{},"RunData":{"dialogueTitle":"Narrator","textBox":"{{{totalNumberOfIterations - 1}}}"}}""",
                result);

            for (int i = 0; i < totalNumberOfIterations; i++)
            {
                result = rynClient.RequestUndo(saveName);
            }

            Assert.Equal(
                """{"Persistent":{},"RunData":{"dialogueTitle":"Narrator","textBox":"First Message!"}}""",
                result);

            Console.WriteLine(result);
        }
    }
}
