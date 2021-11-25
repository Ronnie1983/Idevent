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

        private IDbConnection _dbConnection = new SqlConnection(AppSettings.ConnectionString);

        public List<CompanyModel> GetAll()
        {
            //SELECT C.id, C.Name, C.CVR, C.PhoneNumber, C.Email, C.CVR, C.Note, A.Id, A.StreetAddress,A.City, A.PostalCode, A.Country, B.Id, B.StreetAddress, B.City, B.PostalCode, B.Country
            string sql = "EXECUTE spGetAllCompanies";
           
            Func<CompanyModel,AddressModel, AddressModel, CompanyModel> mapping = (companyModel, addressModel, InvoiceModel) =>
            {
                companyModel.Address = addressModel;
                companyModel.InvoiceAddress = InvoiceModel;

                return companyModel;
            };
            List<CompanyModel> companies = _dbConnection.Query(sql, mapping).AsList();
            return companies;
        }

        public CompanyModel GetById(int id)
        {
            string sql = "EXECUTE spGetCompanyById @companyId";
            CompanyModel result = _dbConnection.QuerySingle<CompanyModel>(sql, new {companyId = id});
            return result;
        }

        public int Create(CompanyModel value)
        {
            //VALUES (@name, @logo, @cvr, @email, @phoneNumber, @active, @note, @addressId, @invoiceAddress)
            var parameter = new { name = value.Name, logo = value.Logo, cvr = value.CVR, email = value.Email, phoneNumber = value.PhoneNumber, active = value.Active, note = value.Note, addressId = value.Address.Id, invoiceAddress = value.InvoiceAddress.Id };
            string sql = "EXECUTE spCreateCompany @name, @logo, @cvr, @email, @phoneNumber, @active, @note, @addressId, @invoiceAddress";
            var result = _dbConnection.ExecuteScalar(sql, parameter);
            if (result == null)
            {
                return Convert.ToInt32(result);
            }
            return 0;
        }
    }
}
