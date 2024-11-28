using BitFaster.Caching.Lru;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Ryngine.DataStructures
{
    public class DbCache<TKey, TValue>
        (SqliteConnection db, string tableName, string keyName, string valueName)
        : IDict<TKey, TValue>
            where TKey : notnull
            where TValue : notnull
    {
        // This should probably be controlled by cache memory size instead of a fixed number.
        public const int CacheSize = 100;

        private readonly SqliteConnection db = db;
        private readonly ConcurrentLru<TKey, TValue> cache = new(CacheSize);

        private readonly string tableName = tableName;
        private readonly string keyName = keyName;
        private readonly string valueName = valueName;

        private bool isInitialized = false;

        public bool TryGet(TKey key, [NotNullWhen(true)] out TValue? value)
        {
            if (cache.TryGet(key, out value))
            {
                return true;
            }

            EnsureInitialized();
            var cmd = new SqliteCommand($"SELECT `{valueName}` from `{tableName}` WHERE `{keyName}` = @key", db);
            cmd.Parameters.AddWithValue("key", key);

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                value = JsonConvert.DeserializeObject<TValue>(reader.GetString(0))
                    ?? throw new Exception("A null object was stored in the DB.");
                cache.AddOrUpdate(key, value);
                return true;
            }

            value = default;
            return false;
        }

        public TValue this[TKey key]
        {
            get
            {
                TryGet(key, out var value);
                if (value is null)
                {
                    throw new IndexOutOfRangeException($"key \"{key}\" not found.");
                }

                return value;
            }

            set
            {
                cache.AddOrUpdate(key, value);

                // Store the update in the DB as well.
                EnsureInitialized();
                string jsonString = JsonConvert.SerializeObject(value);
                var cmd = new SqliteCommand(
                    $"INSERT INTO `{tableName}` (`{keyName}`, `{valueName}`) Values (@key, @value)", db);
                cmd.Parameters.AddWithValue("@key", key);
                cmd.Parameters.AddWithValue("@value", jsonString);
                cmd.ExecuteNonQuery();
            }
        }

        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key))
            {
                throw new ArgumentException($"An element with the same key {key} already exists in the DbCache.");
            }
            this[key] = value;
        }

        public bool ContainsKey(TKey key)
        {
            return TryGet(key, out _);
        }

        private void EnsureInitialized()
        {
            if (isInitialized)
            {
                return;
            }
            isInitialized = true;

            string pkType = (typeof(TKey) == typeof(int) || typeof(TKey) == typeof(long))
                ? "INTEGER(64)"
                : "VARCHAR";

            var sql = $"""
                CREATE TABLE IF NOT EXISTS `{tableName}` (
                    `{keyName}` {pkType} PRIMARY KEY,
                    `{valueName}` MEDIUMTEXT NOT NULL
                );
                CREATE INDEX IF NOT EXISTS `{keyName}_Index` on `{tableName}` (`{keyName}`);
            """;

            using var command = new SqliteCommand(sql, db);
            command.ExecuteNonQuery();
        }
    }
}
