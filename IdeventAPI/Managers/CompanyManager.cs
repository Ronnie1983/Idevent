using Dapper;
using IdeventLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IdeventAPI.Managers
{
    public class CompanyManager
    {
        private IDbConnection _dbConnection = new SqlConnection(Helpers.ConnectionString);

        public List<CompanyModel> GetAll()
        {
            string sql = "EXECUTE spGetAllCompanies";

            Func<CompanyModel,AddressModel, CompanyModel> mapping = (companyModel, addressModel) =>
            {
                companyModel.Address = addressModel;
                companyModel.InvoiceAddress = addressModel;

                return companyModel;
            };
            List<CompanyModel> companies = _dbConnection.Query(sql, mapping).AsList();
            return companies;
        }
    }
}
