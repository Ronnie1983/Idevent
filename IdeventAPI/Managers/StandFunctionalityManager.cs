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
        private IDbConnection _dbConnection = new SqlConnection(AppSettings.ConnectionString);
        public List<StandFunctionalityModel> GetAllByEventId(int id)
        {
            string sql = "EXECUTE spGetAllFunctionsForEvent @eventId";

            List<StandFunctionalityModel> functions = _dbConnection.Query<StandFunctionalityModel>(sql,new {eventId = id}).AsList();

            return functions;
        }
    }
}
