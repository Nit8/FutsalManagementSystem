using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SQLiteDatabaseService
    {
        public string ConnectionString { get; set; }
        public string dbPath { get; }

        private SQLiteConnection _sqLiteConnection;

        public SQLiteConnection sqLiteConnection
        {
            get { return _sqLiteConnection; }
            set { _sqLiteConnection = value; }
        }

        public SQLiteDatabaseService(string dbPath)
        {
            ConnectionString = $@"Data Source = {dbPath}; Version = 3; PRAGMA journal_mode = WAL; Pooling = True; Integrated Security =True;";
        }

        public DbTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void CreateAndOpenConnection()
        {
            try
            {
                sqLiteConnection = new SQLiteConnection(ConnectionString);
                sqLiteConnection.Open();
            }
            catch (Exception)
            {
                // Log
            }
        }

        public void DeleteAndCloseConnection()
        {
            if (sqLiteConnection != null)
            {
                ConnectionString = null;
                sqLiteConnection.Close();
                sqLiteConnection = null;
            }
        }

        public DbConnection GetConnection()
        {
            if (sqLiteConnection == null)
            {
                CreateAndOpenConnection();
            }
            return sqLiteConnection;
        }
    }
}
