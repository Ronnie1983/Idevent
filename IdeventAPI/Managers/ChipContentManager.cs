using IdeventLibrary;
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
        public int Create(ChipContentModel contentModel)
        {
            throw new NotImplementedException();
        }

        private Func<StandProductModel, EventStandModel, StandProductModel> mapping = (standProductModel, eventStandModel) =>
        {
            standProductModel.EventStandModel = eventStandModel;

            return standProductModel;
        };


        public bool CreateMultiple(List<ChipContentModel> chipContentList)
        {
            bool success;
            try
            {
                string sql = "EXECUTE spCreateChipContent @ProductId, @ChipId, @GroupId, @Amount";
                DynamicParameters parameters = new DynamicParameters();

                foreach (ChipContentModel content in chipContentList)
                {
                    parameters.Add("ProductId", content.StandProduct.Id);
                    parameters.Add("ChipId", content.ChipId);
                    parameters.Add("Amount", content.StandProduct.Amount);
                    if (content.GroupId == 0)
                    {
                        parameters.Add("GroupId", null);
                        _dbConnection.Execute(sql, parameters);
                        continue;
                    }
                     parameters.Add("GroupId", content.GroupId);
                    _dbConnection.Execute(sql, parameters);
                }
                success = true;
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                success = false;
                return success;
            }
        }

        public List<StandProductModel> GetAllByChipId(int id)
        {
            string sql = "EXECUTE spGetChipContentByChipId @Id";
            List<StandProductModel> result = _dbConnection.Query(sql, mapping, new {Id = id}, splitOn: "Id").AsList();
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
