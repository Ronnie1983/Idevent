using IdeventLibrary;
using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using IdeventLibrary.Models;

namespace IdeventAPI.Managers
{
    public class UserManager
    {
        IDbConnection _dbConnection;

        public UserManager()
        {
            _dbConnection = new SqlConnection(AppSettings.ConnectionString);
        }
        public UserManager(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        private Func<UserModel, CompanyModel, AddressModel, AddressModel, UserModel> mapping = (userModel, companyModel, addressModel, InvoiceModel) =>
        {
            userModel.Address = addressModel;
            userModel.InvoiceAddress = InvoiceModel;
            userModel.Company = companyModel;

            return userModel;
        };

        public object GetByEmail(string email)
        {
            string sql = "EXECUTE spGetUserByEmail @email";
            var result = _dbConnection.Query(sql, mapping, new { email = email }).AsList();
            return result[0];
        }
    }
}
