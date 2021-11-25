using System.Data;
using System.Data.SqlClient;

namespace IdeventAPI.Managers
{
    public class ChipGroupManager
    {
        IDbConnection _dbConnection;

        public ChipGroupManager()
        {
            _dbConnection = new SqlConnection(AppSettings.ConnectionString);
        }
        public ChipGroupManager(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }
    }
}
