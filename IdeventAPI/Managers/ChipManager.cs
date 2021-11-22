using Dapper;
using IdeventLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace IdeventAPI.Managers
{
    public class ChipManager
    {
        IDbConnection _dbConnection;

        public ChipManager()
        {
            _dbConnection = new SqlConnection(AppSettings.ConnectionString);
        }
        public List<ChipModel> GetAll()
        {
            return new List<ChipModel>();
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
                    }, parameters,
                    splitOn: "Id").Single();

                // TODO: query to get content on the chip (add to output variable)
                // sql = "EXECUTE spGetChipContentById @Id"
                // output.ProductsOnChip = 

                return output;
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
