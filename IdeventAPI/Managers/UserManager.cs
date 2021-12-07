using IdeventLibrary;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using IdeventLibrary.Models;

namespace IdeventAPI.Managers
{
    public class UserManager
    {
        IDbConnection _dbConnection;

        public UserManager()
        {
            _dbConnection = new SqlConnection(AppSettings.ConnectionString);
        }
        public UserManager(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public UserModel GetById(int id)
        {
            string sql = "EXECUTE spGetUserById @UserId";
            var result = _dbConnection.Query(sql, mapping, new { userId = id }).AsList();
            return result[0];
        }
    }
}
