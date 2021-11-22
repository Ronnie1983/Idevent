using Dapper;
using IdeventLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IdeventAPI.Managers
{
    public class ChipManager
    {
        IDbConnection _dbConnection;

        ChipManager()
        {
            _dbConnection = new SqlConnection(AppSettings.ConnectionString);
        }
        public List<ChipModel> GetAll()
        {
            return new List<ChipModel>();
        }
        public ChipModel GetById(int id)
        {
            throw new NotImplementedException();
            //// Columns: Chips.Id, ValidFrom, ValidTo, ChipGroups.Id, ChipGroups.Name, Id, CompanyName, Email, Id, EventName
            //string sql = "EXECUTE spGetChipById @Id";
            //var parameters = new { Id = id };

            //ChipModel output = _dbConnection.QuerySingle<CommandDefinition>
            //    (sql,
            //    (chipModel, groupModel, companyModel, eventModel) => { 
            //        chipModel.Group = groupModel;


            //        return chipModel;
            //    },
            //    parameters).AsList();

            //return output;
        }
    }
}
