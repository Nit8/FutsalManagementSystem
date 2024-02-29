using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DatabaseHelper : IDBHelper
    {

        public readonly DbConnection _connection;
        public DatabaseHelper(DbConnection dBConnectionService)
        {
            _connection = dBConnectionService;
        }
        public void CreateDatabase(string databasePath)
        {
            using (var connection = new SQLiteConnection($"Data Source={databasePath}"))
            {
                connection.Open();

                string sql = @"
                CREATE TABLE IF NOT EXISTS Slots (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date DATE NOT NULL,
                    Ground TEXT NOT NULL,
                    StartTime TIME NOT NULL,
                    EndTime TIME NOT NULL,
                    Booked BOOLEAN NOT NULL DEFAULT 0
                );
            ";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
