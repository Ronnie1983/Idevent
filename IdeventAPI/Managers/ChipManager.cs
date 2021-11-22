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
            string sql = "EXECUTE spGetChipById @Id";

            ChipModel output = _dbConnection.Query<ChipModel, EventModel, CompanyModel, StandProductModel>(){

            }
        }
    }
}
