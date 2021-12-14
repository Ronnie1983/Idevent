using Dapper;
using IdeventLibrary;
using IdeventLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;

namespace IdeventAPI.Managers
{
    public class ChipManager
    {
        IDbConnection _dbConnection;
        private ChipContentManager _contentManager;

        public ChipManager()
        {
            _dbConnection = new SqlConnection(AppSettings.ConnectionString);
            _contentManager = new ChipContentManager();
        }
        public ChipManager(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
            _contentManager = new ChipContentManager(connectionString);
        }

        public int Create(ChipModel newChip)
        {
            try
            {
                string sql = "spCreateChip @HashedId, @ValidFrom, @ValidTo, @CompanyId, @EventId, @ChipGroupId, @UserId";
               
                DynamicParameters parameters = new();

                parameters.Add("HashedId", newChip.HashedId);
                parameters.Add("ValidFrom", newChip.ValidFrom);
                parameters.Add("ValidTo", newChip.ValidTo);
                parameters.Add("CompanyId", newChip.Company.Id);

                parameters.Add("EventId", null);
                parameters.Add("ChipGroupId", null);
                parameters.Add("UserId", null);
               
                if (newChip.Group?.Id == 0)
                {
                    parameters.Add("ChipGroupId", newChip.Group.Id);
                }
                if(newChip.Event != null)
                {
                    parameters.Add("EventId", newChip.Event.Id);
                }
                Object newChipId = _dbConnection.ExecuteScalar(sql, parameters);
                if (newChipId != null)
                {
                    return Convert.ToInt32(newChipId);
                }
                return 0;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public List<ChipModel> GetAll()
        {
            try
            {
                string sql = "EXECUTE spGetAllChips";

                List<ChipModel> output = _dbConnection.Query<ChipModel, CompanyModel, ChipGroupModel, EventModel, ChipModel>(sql,
                    (chipModel, companyModel, chipGroupModel, eventModel) =>
                    {
                        chipModel.Company = companyModel;
                        chipModel.Group = chipGroupModel;
                        chipModel.Event = eventModel;

                        return chipModel;
                    }).ToList();

                return output;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            return null;
        }
        public ChipModel GetById(int id)
        {
            try
            {
                // Columns: Chips.Id, ValidFrom, ValidTo, ChipGroups.Id, ChipGroups.Name, Id, CompanyName, Email, Id, EventName
                string sql = "EXECUTE spGetChipById @Id";
                var parameters = new { Id = id };

                // TODO: Add UserModel to Query (for Users Email)
                ChipModel output = _dbConnection.Query<ChipModel, ChipGroupModel, CompanyModel, EventModel, ChipModel>
                    (sql, (chipModel, groupModel, companyModel, eventModel) =>
                    {
                        chipModel.Group = groupModel;
                        chipModel.Company = companyModel;
                        chipModel.Event = eventModel;

                        return chipModel;
                    }, parameters, splitOn: "Id").Single();

                // Gets products from chip content
                output.StandProducts = _contentManager.GetAllByChipId(Convert.ToInt32(output.Id));

                return output;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                if (ex.StackTrace.Contains("NoElements"))
                {
                    return null;
                }
                throw;
            }
        }

        public ChipModel GetByHashedId(string id)
        {
            try
            {
                // Columns: Chips.Id, ValidFrom, ValidTo, ChipGroups.Id, ChipGroups.Name, Id, CompanyName, Email, Id, EventName
                string sql = "EXECUTE spGetChipByHashedId @Id";
                var parameters = new { Id = id };

                // TODO: Add UserModel to Query (for Users Email)
                ChipModel output = _dbConnection.Query<ChipModel, ChipGroupModel, CompanyModel, EventModel, ChipModel>
                    (sql, (chipModel, groupModel, companyModel, eventModel) =>
                    {
                        chipModel.Group = groupModel;
                        chipModel.Company = companyModel;
                        chipModel.Event = eventModel;

                        return chipModel;
                    }, parameters, splitOn: "Id").Single();

                
                output.StandProducts = _contentManager.GetAllByChipId(Convert.ToInt32(output.Id));

                return output;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                if (ex.StackTrace.Contains("NoElements"))
                {
                    return null;
                }
                throw;
            }
        }
    }
}
