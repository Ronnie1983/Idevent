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

        public bool Update(UserModel updatedModel)
        {
            bool success = false;
            string sql = "EXECUTE spUpdateUser @Id, @UserName, @Email, @PhoneNumber";
            DynamicParameters parameters = new DynamicParameters();

            if (updatedModel.Address.Id > 0)
            {
                sql = "EXECUTE spUpdateUser @Id, @UserName, @Email, @PhoneNumber, @CompanyId ,@AddressId, @StreetAddress, @Country, @City, @PostalCode";
                parameters.Add("@StreetAddress", updatedModel.Address.StreetAddress);
                parameters.Add("@Country", updatedModel.Address.Country);
                parameters.Add("@City", updatedModel.Address.City);
                parameters.Add("@PostalCode", updatedModel.Address.PostalCode);
            }
            parameters.Add("@Id", updatedModel.Id);
            parameters.Add("@UserName", updatedModel.UserName);
            parameters.Add("@Email", updatedModel.Email);
            parameters.Add("@PhoneNumber", updatedModel.PhoneNumber);
            parameters.Add("@CompanyId", updatedModel.Company.Id);
            parameters.Add("@AddressId", updatedModel.Address.Id);

            int affectedRows = _dbConnection.Execute(sql, parameters);
            if(affectedRows == 1)
            {
                success = true;
            }
            return success;
        }

        public UserModel GetById(string userId)
        {
            // Users.Id, Users.UserName, Users.Email, Users.PhoneNumber, A.Id, A.StreetAddress, A.City, A.Country, A.PostalCode
            string sql = "EXECUTE spGetUserById @userId";
            UserModel result = _dbConnection.QuerySingle<UserModel>(sql, new { userId = userId });
            
            return result;
        }
    }
}
