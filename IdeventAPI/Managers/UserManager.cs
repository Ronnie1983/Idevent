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
            string sql = "EXECUTE spUpdateUser @Id, @UserName, @Email, @PhoneNumber, @CompanyId";
            DynamicParameters parameters = new DynamicParameters();

            if (updatedModel.Address.Id > 0)
            {
                sql = "EXECUTE spUpdateUser @Id, @UserName, @Email, @PhoneNumber, @CompanyId ,@AddressId, @StreetAddress, @City, @Country , @PostalCode";
                parameters.Add("@StreetAddress", updatedModel.Address.StreetAddress);
                parameters.Add("@Country", updatedModel.Address.Country);
                parameters.Add("@City", updatedModel.Address.City);
                parameters.Add("@PostalCode", updatedModel.Address.PostalCode);
            }
            parameters.Add("@Id", updatedModel.Id);
            parameters.Add("@UserName", updatedModel.UserName);
            parameters.Add("@Email", updatedModel.Email);
            parameters.Add("@PhoneNumber", updatedModel.PhoneNumber);
            parameters.Add("@CompanyId", null);
            if (updatedModel.Company != null)
            {
                parameters.Add("@CompanyId", updatedModel.Company.Id); // overwrites previous @CompanyId 
            }
            parameters.Add("@AddressId", updatedModel.Address.Id);

            int affectedRows = _dbConnection.Execute(sql, parameters);
            if(affectedRows == 1 || affectedRows == 2)
            {
                success = true;
            }
            return success;
        }

        public bool UpdateRole(UserModel updatedModel)
        {
            bool success = false;
            string sql = "EXECUTE spUpdateUserRole @roleName, @userId";
            var parameters = new { roleName = updatedModel.Role, userId = updatedModel.Id };
            int affectedRows = _dbConnection.Execute(sql, parameters);
            if(affectedRows == 1)
            {
                success = true;
            }
            return success;
        }

        public bool DeleteById(string id)
        {
            string sql = "EXECUTE spDeleteUserById @userId";
            int result = _dbConnection.Execute(sql,new { userId = id });
            if(result > 0)
            {
                return true;
            }
            return false;
        }

        public UserModel GetById(string userId)
        {
            // Users.Id, Users.UserName, Users.Email, Users.PhoneNumber,
            // Users.CompanyId AS Id, A.Id, A.StreetAddress, A.City, A.Country, A.PostalCode, A2.Id, A2.StreetAddress, A2.City, A2.Country, A2.PostalCode
            string sql = "EXECUTE spGetUserById @userId";
            UserModel result = _dbConnection.Query(sql, _mapping, new { userId = userId }).Single();
            
            return result;
        }
    }
}
