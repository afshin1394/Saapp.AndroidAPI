using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Infra.Data.SqlServer.Common
{
    public class DapperBaseRepository
    {
        protected readonly IDbConnection dbConnection;
        public DapperBaseRepository(DatabaseOptions databaseOptions)
        {
            dbConnection = new SqlConnection(databaseOptions.ConnectionString);
            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();
        }
        public void Dispose()
        {
            if (dbConnection != null)
            {
                dbConnection.Close();
            }
        }

    }
}
