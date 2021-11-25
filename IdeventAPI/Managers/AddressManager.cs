using IdeventLibrary.Models;
using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IdeventAPI.Managers
{
    public class AddressManager
    {
        private IDbConnection _dbConnection = new SqlConnection(AppSettings.ConnectionString);

        public AddressModel GetById(int id)
        {
            string sql = "EXECUTE spGetAddressById @addressId";
            AddressModel result = _dbConnection.QuerySingle<AddressModel>(sql, new {addressId = id});
            return result;
        }

        public int Create(AddressModel value)
        {
            var parameter = new { street = value.StreetAddress, city = value.City, postal = value.PostalCode, country = value.Country};
            string sql = "EXECUTE spCreateAddress @street, @city, @postal, @country";
            var result = _dbConnection.ExecuteScalar(sql, parameter);
            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            return 0;
        }
    }
}
