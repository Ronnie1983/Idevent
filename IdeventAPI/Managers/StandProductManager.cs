using System;
using Dapper;
using IdeventLibrary.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IdeventAPI.Managers
{
    public class StandProductManager
    {
        private IDbConnection _dbConnection = new SqlConnection(AppSettings.ConnectionString);
        public List<StandProductModel> GetAll()
        {
            string sql = "EXECUTE spGetAllProducts";

            Func<StandProductModel, EventStandModel, StandProductModel> mapping = (product, stand) =>
            {
                product.EventStandModel = stand;
                return product;
            };
            List<StandProductModel> products = _dbConnection.Query(sql, mapping).AsList();
            return products;
        }

        public int Create(StandProductModel item)
        {
            string sql = $"EXECUTE spCreateProduct {item.Name}, {item.Value}, {item.EventStandModel.Id}";
            var rowEffected = _dbConnection.Execute(sql);

            return rowEffected;
        }
    }
}
