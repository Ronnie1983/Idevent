using System.Data;
using System.Data.SqlClient;

namespace IdeventAPI.Managers
{
    public class CompanyPermissionManager
    {
        IDbConnection _dbConnection;

        public CompanyPermissionManager()
        {
            _dbConnection = new SqlConnection(AppSettings.ConnectionString);
        }
        public CompanyPermissionManager(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);

        }
    }
}
