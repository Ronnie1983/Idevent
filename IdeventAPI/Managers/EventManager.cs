using Dapper;
using IdeventLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IdeventAPI.Managers
{
    public class EventManager
    {
        private IDbConnection _dbConnection = new SqlConnection(Helpers.ConnectionString);
            
        public List<EventModel> GetAll()
        {
            throw new NotImplementedException();
            string sql = "EXECUTE spGetAllEvents";

            //List<EventModel> events = _dbConnection.Query<EventModel, CompanyModel>(sql);

        }
    }
}
