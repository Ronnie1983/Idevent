using System.Data;
using System.Data.SqlClient;

namespace IdeventAPI.Managers
{
    public class PermissionManager
    {
        IDbConnection _dbConnection;

        public PermissionManager()
        {
            _dbConnection = new SqlConnection(AppSettings.ConnectionString);
        }
        public PermissionManager(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }
    }
}
