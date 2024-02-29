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
            SQLiteDatabaseService sqLite = new SQLiteDatabaseService("D:\\Projects\\FutsalManagementSystem\\src\\FMS\\FMS\\DataAccessLayer\\resources\\testDB.db");
            var sqConn = sqLite.GetConnection();
            sqLite.DeleteAndCloseConnection();
        }
    }
}
