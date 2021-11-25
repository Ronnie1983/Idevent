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
            List<EventStandModel> eventStands = _dbConnection.Query<EventStandModel, EventModel, StandFunctionalityModel, EventStandModel>(
                sql, (eventStandModel, eventModel, standFunctionModel) =>
           {
               eventStandModel.Event = eventModel;
               eventStandModel.Functionality = standFunctionModel;
               return eventStandModel;
           }, new { eventId = id }, splitOn: "Id").AsList();

         
            return eventStands;
        }

        //public EventStandModel GetById(int id)
        //{
        //    string sql = $"EXECUTE spGetStandById @eventId";
        //    List<EventStandModel> eventStand = _dbConnection.Query<EventStandModel, EventModel, StandFunctionalityModel, EventStandModel>(
        //        sql, (eventStandModel, eventModel, standFunctionModel) =>
        //        {
        //            eventStandModel.Event = eventModel;
        //            eventStandModel.Functionality = standFunctionModel;
        //            return eventStandModel;
        //        }, new { eventId = id }, splitOn: "Id").AsList();


        //    return eventStand[0];
        //}

        public EventStandModel GetById(int id)
        {
            string sql = $"EXECUTE spGetStandById @eventId";
            List<EventStandModel> eventStand = _dbConnection.Query<EventStandModel, EventModel, StandFunctionalityModel, EventStandModel>(
                sql, (eventStandModel, eventModel, standFunctionModel) =>
                {
                    eventStandModel.Event = eventModel;
                    eventStandModel.Functionality = standFunctionModel;
                    return eventStandModel;
                }, new { eventId = id }, splitOn: "Id").AsList();


            return eventStand[0];
        }

        public int Create(EventStandModel item)
        {
            string sql = $"EXECUTE spCreateStand @name, @eventId, @funktionalityId";
            var result = _dbConnection.ExecuteScalar(sql,new {name = item.Name, eventId = item.EventID, funktionalityId = item.FunctionalityId});
            if(result != null)
            {
                return Convert.ToInt32(result);
            }
            return 0;
        }

        public int Update(int id, string item)
        {
            string sql = $"EXECUTE spUpdateStandName @standId, @name";
            var rowEffected = _dbConnection.Execute(sql, new { standId = id, name = item });

            return rowEffected;
        }

        public int Delete(int id)
        {
            string sql = $"EXECUTE spDeleteStand @standId";
            var result = _dbConnection.Execute(sql, new { standId = id });
            return result;
        }
    }
}
