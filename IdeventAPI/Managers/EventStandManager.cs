using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using IdeventLibrary.Models;

namespace IdeventAPI.Managers
{
    public class EventStandManager
    {
        private IDbConnection _dbConnection = new SqlConnection(AppSettings.ConnectionString);

        public List<EventStandModel> GetAll()
        {
            //SELECT E.Id, E.Name, A.Id, A.Name, S.Id, S.Name
            string sql = "EXECUTE spGetAllEventStands";
            Func<EventStandModel, EventModel, StandFunctionalityModel, EventStandModel> mapping = (eventStandModel, eventModel, standFunctionModel) =>
            {
                eventStandModel.Event = eventModel;
                eventStandModel.Functionalities = standFunctionModel;
                return eventStandModel;
            };
            List<EventStandModel> eventStands = _dbConnection.Query(sql, mapping).AsList();
            return eventStands;
        }
    }
}
