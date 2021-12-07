using System;
using IdeventLibrary;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        public UserModel GetById(string id)
        {
            string sql = "EXECUTE spGetUserById @userId";
            UserModel result = _dbConnection.QuerySingle<UserModel>(sql, new { userId = id });
            return result;
        }
    }
}
