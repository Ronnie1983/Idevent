using IdeventLibrary;
using IdeventLibrary.Models;
using System.Data;
using System.Data.SqlClient;
using System;
using Dapper;

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
                string sql = "spCreateChipGroup @Name";
                var parameters = new { Name = newChipGroup.Name };
                Object createdId = _dbConnection.ExecuteScalar(sql, parameters, null, null, CommandType.StoredProcedure);
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
    }
}
