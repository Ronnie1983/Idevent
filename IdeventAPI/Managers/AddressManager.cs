using System.Data;
using System.Data.SqlClient;

namespace IdeventAPI.Managers
{
    public class AddressManager
    {
        IDbConnection _dbConnection;

        public AddressManager()
        {
            _dbConnection = new SqlConnection(AppSettings.ConnectionString);
        }
        public AddressManager(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }
    }
}
