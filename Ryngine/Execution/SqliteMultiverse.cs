using Microsoft.Data.Sqlite;
using Newtonsoft.Json.Linq;
using Ryngine.DataStructures;

namespace Ryngine.Execution;

public class SqliteMultiverse(SqliteConnection sqliteConnection) : IMultiverse
{
    private const int PersistentDataCacheKey = 0;

    private readonly SqliteConnection sqliteConnection = sqliteConnection;
    
    private readonly DbCache<string, Snapshot> allSavesDbCache = new(
        sqliteConnection,
        tableName: "AllSaves",
        keyName: "Id",
        valueName: "Snapshot");

    private readonly DbCache<UndoRecordId, UndoRecord> undoRecordsDbCache = new(
        sqliteConnection,
        tableName: "UndoRecords",
        keyName: "Id",
        valueName: "UndoRecord");

    private readonly DbCache<int, JObject> persistentDataCache = new(
        sqliteConnection,
        tableName: "PersistentDatas",
        keyName: "Id",
        valueName: "PersistentData");

    public IDict<string, Snapshot> AllSaves
    {
        get
        {
            EnsureInitialized();
            return allSavesDbCache;
        }
    }

    public JObject PersistentData
    {
        get
        {
            EnsureInitialized();

            // A bit of a hack, but not worth persuing optimization for now.
            if (persistentDataCache.TryGet(PersistentDataCacheKey, out JObject? persistentData))
            {
                return persistentData;
            }
            persistentDataCache[PersistentDataCacheKey] = [];

            return persistentDataCache[PersistentDataCacheKey];
        }
        set
        {
            EnsureInitialized();
            persistentDataCache[PersistentDataCacheKey] = value;
        }
    }

    public IDict<UndoRecordId, UndoRecord> UndoRecords
    {
        get
        {
            EnsureInitialized();
            return undoRecordsDbCache;
        }
    }

    public Snapshot CurrentSave { get; set; } = new(UndoRecord.RootRecord);

    private void EnsureInitialized()
    {
        if (sqliteConnection.State == System.Data.ConnectionState.Closed)
        {
            sqliteConnection.Open();
        }
    }
}
