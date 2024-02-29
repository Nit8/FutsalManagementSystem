using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDBConnectionService
    {
        string ConnectionString { get; set; }
        void CreateAndOpenConnection();
        void DeleteAndCloseConnection();
        DbTransaction BeginTransaction();
        DbConnection GetConnection();
    }
}
