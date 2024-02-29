using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutsalManagementSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TestDB();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        private static void TestDB()
        {
            string dbPath = @"D:\\Projects\\FutsalManagementSystem\\src\\FMS\\FMS\\DataAccessLayer\\resources\\testDB.db";
            IDBConnectionService sqLite = new SQLiteDatabaseService(dbPath);
            var sqConn = sqLite.GetConnection();
            IDBHelper dBHelper = new DatabaseHelper(sqConn);
            dBHelper.CreateDatabase(dbPath);

        }
    }
}
