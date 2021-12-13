﻿using IdeventLibrary;
using System;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using IdeventLibrary.Models;
using System.Collections.Generic;

namespace IdeventAPI.Managers
{
    public class ChipContentManager
    {
        IDbConnection _dbConnection;

        public ChipContentManager()
        {
            _dbConnection = new SqlConnection(AppSettings.ConnectionString);
        }
        public ChipContentManager(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public List<StandProductModel> GetAllByChipId(int id)
        {
            string sql = "EXECUTE spGetChipContentByChipId @Id";
            List<StandProductModel> result = _dbConnection.Query<StandProductModel>(sql, new {Id = id}).AsList();
            return result;
        }

        public List<StandProductModel> GetAllByChipAndStandId(int chipId, int standId)
        {
            string sql = "EXECUTE spGetStandProductAndContentByChipId @chipId, @standId ";
            List<StandProductModel> result = _dbConnection.Query<StandProductModel>(sql, new { chipId = chipId, standId = standId }).AsList();
            return result;
        }
    }
}
