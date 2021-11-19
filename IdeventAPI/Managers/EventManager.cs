using Dapper;
using IdeventLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IdeventAPI.Managers
{
    public class EventManager
    {
        private IDbConnection _dbConnection;

        public EventManager()
        {
            _dbConnection = new SqlConnection(AppSettings.ConnectionString);
        }

        public List<EventModel> GetAll()
        {
            // Column order: (Event)Id, Name, NumberOfConnectedChips, (Company)Id, CompanyName
            string sql = "EXECUTE spGetAllEvents";

            Func<EventModel, CompanyModel, EventModel> mapping = (eventModel, companyModel) =>
            {
                eventModel.Company = companyModel;

                return eventModel;
            };

            List<EventModel> events = _dbConnection.Query(sql, mapping).AsList();

            return events;
        }
    }
}
