using System;
using Dapper;
using IdeventLibrary.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace IdeventAPI.Managers
{
    public class StandFunctionalityManager
    {
        IDbConnection _dbConnection;

        public StandFunctionalityManager()
        {
            _dbConnection = new SqlConnection(AppSettings.ConnectionString);
        }
        public StandFunctionalityManager(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public List<StandFunctionalityModel> GetAll()
        {
            string sql = "EXECUTE spGetAllFunctions";

            List<StandFunctionalityModel> functions = _dbConnection.Query<StandFunctionalityModel>(sql).AsList();

            return functions;
        }
    }
}
