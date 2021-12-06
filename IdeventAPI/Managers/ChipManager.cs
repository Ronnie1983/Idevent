using Dapper;
using IdeventLibrary;
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
        public ChipManager(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
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

                // StandProducts.Name, ChipContents.Amount
                sql = "EXECUTE spGetChipContentByChipId @Id";
                IEnumerable<dynamic> productsOnChip = _dbConnection.Query(sql, parameters);

                output.ProductsOnChip = new Dictionary<string, int>();
                foreach (dynamic item in productsOnChip)
                {
                    output.ProductsOnChip.Add(item.Name, item.Amount);
                }
                return output;
            }
            catch(SqlException ex)
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

        internal ChipModel GetBySecretId(string id)
        {
            try
            {
                // Columns: Chips.Id, ValidFrom, ValidTo, ChipGroups.Id, ChipGroups.Name, Id, CompanyName, Email, Id, EventName
                string sql = "EXECUTE spGetChipBySecretId @Id";
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

                // StandProducts.Name, ChipContents.Amount
                sql = "EXECUTE spGetChipContentByChipId @Id";
                IEnumerable<dynamic> productsOnChip = _dbConnection.Query(sql, parameters);

                output.ProductsOnChip = new Dictionary<string, int>();
                foreach (dynamic item in productsOnChip)
                {
                    output.ProductsOnChip.Add(item.Name, item.Amount);
                }
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
