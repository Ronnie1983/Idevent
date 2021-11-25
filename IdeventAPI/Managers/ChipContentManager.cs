using System.Data;
using System.Data.SqlClient;

namespace IdeventAPI.Managers
{
    public class ChipContentManager
    {
        IDbConnection _dbConnection;

        public ChipContentManager()
        {
            _dbConnection = new SqlConnection(AppSettings.ConnectionString);
        }
        public ChipContentManager(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }
    }
}
