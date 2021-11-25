using System.Data;
using System.Data.SqlClient;

namespace IdeventAPI.Managers
{
    public class ChipActivityManager
    {
        IDbConnection _dbConnection;

        public ChipActivityManager()
        {
            _dbConnection = new SqlConnection(AppSettings.ConnectionString);
        }
        public ChipActivityManager(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }
    }
}
