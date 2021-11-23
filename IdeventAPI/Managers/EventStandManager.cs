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
                eventStandModel.Functionality = standFunctionModel;
                return eventStandModel;
            };
            List<EventStandModel> eventStands = _dbConnection.Query(sql, mapping).AsList();
            return eventStands;
        }

        public List<EventStandModel> GetAllByEventId(int id)
        {
            string sql = $"EXECUTE spGetStandByEventId @eventId";
            List<EventStandModel> eventStands = _dbConnection.Query<EventStandModel, EventModel, StandFunctionalityModel, EventStandModel>(sql, (eventStandModel, eventModel, standFunctionModel) =>
           {
               eventStandModel.Event = eventModel;
               eventStandModel.Functionality = standFunctionModel;
               return eventStandModel;
           }, new { eventId = id }, splitOn: "Id").AsList();

         
            return eventStands;
        }

        public int Create(EventStandModel item)
        {
            string sql = $"EXECUTE spCreateStand @name, @eventId, @funktionalityId";
            var rowEffected = _dbConnection.Execute(sql,new {name = item.Name, eventId = item.EventID, funktionalityId = item.FunctionalityId});

            return rowEffected;
        }
    }
}
