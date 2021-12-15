using System;
using Dapper;
using IdeventLibrary.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using IdeventLibrary;

namespace IdeventAPI.Managers
{
    public class StandProductManager
    {
        IDbConnection _dbConnection;

        public StandProductManager()
        {
            _dbConnection = new SqlConnection(AppSettings.ConnectionString);
        }
        public StandProductManager(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        private Func<StandProductModel, EventStandModel, StandProductModel> mapping = (standProductModel, eventStandModel) =>
        {
            standProductModel.EventStandModel = eventStandModel;

            return standProductModel;
        };

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
            var parameter = new { name = item.Name, value = item.Value, standId = item.EventStandId };
            string sql = $"EXECUTE spCreateProduct @name, @value, @standId";
            //var rowEffected =_dbConnection.Query<int>(sql);
            var result =_dbConnection.ExecuteScalar(sql, parameter);
            if(result != null)
            {
                return Convert.ToInt32(result);
            }
            return 0;
        }

        public List<StandProductModel> GetAllByStandId(int id)
        {
            string sql = "EXECUTE spGetProductsByStandId @standId";

            List<StandProductModel> products = _dbConnection.Query(sql,mapping, new { standId = id }, splitOn: "Id").AsList();

            return products;
        }
        public List<StandProductModel> GetAllByEventId(int eventId)
        {
            string sql = "EXECUTE spGetAllProductsByEventId @eventId";
            var parameters = new { eventId };

            List<StandProductModel> products = _dbConnection.Query<StandProductModel>(sql, parameters).AsList();

            return products;
        }

        public int Delete(int id)
        {
            string sql = "EXECUTE spDeleteProduct @productId";
            var rowEffected = (_dbConnection.Execute(sql, new {productId = id}));
            return rowEffected;
        }

        public StandProductModel GetById(int id)
        {
            string sql = "EXECUTE spGetProductById @Id";
            StandProductModel result = _dbConnection.QuerySingle<StandProductModel>(sql, new {Id = id});
            return result;
        }
    }
}
