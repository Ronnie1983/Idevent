using System;
using IdeventLibrary;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using Dapper;
using IdeventLibrary.Models;
using System.Collections.Generic;

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


        private Func<UserModel, CompanyModel, AddressModel, AddressModel, UserModel> _mapping = (userModel, companyModel, addressModel, invoiceModel) =>
        {
            userModel.Address = addressModel;
            userModel.InvoiceAddress = invoiceModel;
            userModel.Company = companyModel;

            return userModel;
        };

        /// <summary>
        /// Only retrieves data not made by AspNetCore.Identity.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, UserModel> GetAllCustomData()
        {
            // Users.Id, Users.CompanyId AS Id, Name, AddressId AS Id, InvoiceAddressId AS Id
            string sql = "EXECUTE spGetAllUsersCustomData";

            Dictionary<string, UserModel> output = _dbConnection.Query(sql, _mapping).ToDictionary(x => x.Id, x => x);
            return output;
        }

        public UserModel GetByEmail(string email)
        {
            string sql = "EXECUTE spGetUserByEmail @email";
            var result = _dbConnection.Query(sql, _mapping, new { email = email }).AsList();
            return result[0];
        }

        public UserModel GetById(string id)
        {
            string sql = "EXECUTE spGetUserById @userId";
            UserModel result = _dbConnection.QuerySingle<UserModel>(sql, new { userId = id });
            return result;

        }
    }
}
