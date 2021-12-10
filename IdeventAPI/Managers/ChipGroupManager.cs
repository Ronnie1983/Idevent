using IdeventLibrary;
using IdeventLibrary.Models;
using System.Data;
using System.Data.SqlClient;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace IdeventAPI.Managers
{
    public class ChipGroupManager
    {
        IDbConnection _dbConnection;

        public ChipGroupManager()
        {
            _dbConnection = new SqlConnection(AppSettings.ConnectionString);
        }
        public ChipGroupManager(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public int Create(ChipGroupModel newChipGroup)
        {
            try
            {
                string sql = "spCreateChipGroup @Name, @EventId";
                var parameters = new { newChipGroup.Name, newChipGroup.EventId };
                Object createdId = _dbConnection.ExecuteScalar(sql, parameters);
                if(createdId != null)
                {
                    return Convert.ToInt32(createdId);
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }
        public List<ChipGroupModel> GetAllByEventId(int eventId)
        {
            try
            {
                string sql = "EXECUTE spGetAllChipGroupsByEventId @eventId";
                var parameters = new { eventId };

                List<ChipGroupModel> chipGroups = _dbConnection.Query<ChipGroupModel>(sql, parameters).AsList();

                return chipGroups;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public ChipGroupModel GetById(int chipGroupId)
        {
            try
            {
                string sql = "EXECUTE spGetChipGroupById @chipGroupId";
                var parameters = new { chipGroupId };

                var output = _dbConnection.Query<ChipGroupModel>(sql, parameters).AsList();
                if(output.Count <= 0)
                {
                    return null;
                }
                ChipGroupModel chipGroup = output[0];
                return chipGroup;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
