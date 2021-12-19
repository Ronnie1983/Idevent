using IdeventLibrary;
using System;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using IdeventLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public bool Create(ChipContentModel content)
        {
            var result = 0;
            string sql = "EXECUTE spCreateChipContent @ProductId, @ChipId, @GroupId, @Amount";
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("ProductId", content.StandProduct.Id);
            parameters.Add("ChipId", content.ChipId);
            parameters.Add("Amount", content.StandProduct.Amount);
            if (content.GroupId == 0)
            {
                parameters.Add("GroupId", null);
                result = _dbConnection.Execute(sql, parameters);
                
            }
            else
            {
                parameters.Add("GroupId", content.GroupId);
                result = _dbConnection.Execute(sql, parameters);
            }
       
            if (result == 0)
            {
                return false;
            }
            return true;
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

        public bool CreateAndUpdateMultiple(List<ChipContentModel> chipContentList)
        {
            bool success;

           
                
                foreach (ChipContentModel content in chipContentList)
                {
                    bool exists = GetChipContentByStandProductIdAndChipId(content);
                    if (exists)
                    {
                        UpdateChipContent(content);
                    }
                    else
                    {
                        Create(content);
                    }
                }
                success = true;
                
                return success;
            
        }

        public bool UpdateChipContent(ChipContentModel chipContent)
        {
            string sql = "EXECUTE spUpdateChipContent @standProductId, @chipId, @amount";
            int result = _dbConnection.Execute(sql, new { standProductId = chipContent.StandProduct.Id, chipId = chipContent.ChipId, amount = chipContent.StandProduct.Amount});
            if (result == 0)
            {
                return false;
            }
            return true;
        }

        public bool GetChipContentByStandProductIdAndChipId(ChipContentModel content)
        {
            ChipContentModel result;
            try
            {
                string sql = "EXECUTE spGetChipContentByStandProductIdAndChipId @standProductId, @chipId";
                result = _dbConnection.QuerySingle<ChipContentModel>(sql, new { standProductId = content.StandProduct.Id, chipId = content.ChipId});
            } catch (Exception ex)
            {
                result = null;
            }
            
            if(result == null)
            {
                return false;
            }
            return true;
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
