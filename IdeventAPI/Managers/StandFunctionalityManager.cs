using System;
using Dapper;
using IdeventLibrary.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using IdeventLibrary;

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
        public int Create(StandFunctionalityModel newFunctionality)
        {
            string sql = "EXECUTE spCreateFunctionality @Name"; // TODO: make spCreateFunctionlity
            var parameters = new { newFunctionality.Name };
            object createdId = _dbConnection.ExecuteScalar(sql, parameters);
            if(createdId != null)
            {
                return Convert.ToInt32(createdId);
            }
            return 0;
        }

        public StandFunctionalityModel GetById(int id)
        {
            string sql = "EXECUTE spGetFunctionlaityById @Id"; // TODO: make spGetFunctionalityById
            var parameters = new { Id = id };

            StandFunctionalityModel standFunctionality = _dbConnection.Query(sql, parameters).Single();

            return standFunctionality;
        }
    }
}
