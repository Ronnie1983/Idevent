using Dapper;
using IdeventLibrary;
using IdeventLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace IdeventAPI.Managers
{
    public class EventManager
    {
        private IDbConnection _dbConnection;

        public EventManager()
        {
            _dbConnection = new SqlConnection(AppSettings.ConnectionString);
        }
        public EventManager(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public int Create(EventModel model)
        {
            string sql = "EXECUTE spCreateEvent @Name, @CompanyId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Name", model.Name);
            parameters.Add("CompanyId", model.Company.Id);

            Object createdEventId = _dbConnection.ExecuteScalar(sql, parameters);
            if (createdEventId != null)
            {
                return Convert.ToInt32(createdEventId);
            }
            return 0;
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



        public EventModel GetById(int id)
        {
            // Columns: Event.Id, Name, NumberOfConnectedChips, Company.Id, Name, Email, CVR, PhoneNumber
            string sql = $"EXECUTE spGetEventById @eventId";
            // CompanyModel property order: Id, Name, Email, InvoiceAddress, Address, CVR, PhoneNumber, Note, Active,Logo
            EventModel eventModel = _dbConnection.Query<EventModel, CompanyModel, EventModel>(sql, (eventModel, company) =>
            {
                eventModel.Company = company;
                return eventModel;
            },new {eventId = id}, splitOn: "Id").Single();

            return eventModel;
        }
    }
}
