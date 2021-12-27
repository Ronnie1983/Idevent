using Dapper;
using IdeventLibrary;
using IdeventLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IdeventAPI.Managers
{
    public class CompanyManager
    {

        private IDbConnection _dbConnection;
        private AddressManager _addressManager;

        public CompanyManager()
        {
            _dbConnection = new SqlConnection(AppSettings.ConnectionString);
            _addressManager = new AddressManager();
        }
        public CompanyManager(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }
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

        private Func<CompanyModel, AddressModel, AddressModel, CompanyModel> mapping = (companyModel, addressModel, InvoiceModel) =>
        {
            companyModel.Address = addressModel;
            companyModel.InvoiceAddress = InvoiceModel;

            return companyModel;
        };
   

        public CompanyModel GetById(int id)
        {
            string sql = "EXECUTE spGetCompanyById @companyId";
            var result = _dbConnection.Query(sql, mapping, new {companyId = id}).AsList();
            return result[0];
        }

        public int Create(CompanyModel value)
        {
            //VALUES (@name, @logo, @cvr, @email, @phoneNumber, @active, @note, @addressId, @invoiceAddress)
            var parameter = new { name = value.Name, logo = value.Logo, cvr = value.CVR, email = value.Email, phoneNumber = value.PhoneNumber, active = value.Active, note = value.Note, addressId = ((value.Address == null || value.Address.Id == 0) ? (int?)null : value.Address.Id), invoiceAddress = ((value.InvoiceAddress == null || value.InvoiceAddress.Id == 0) ? (int?)null : value.InvoiceAddress.Id) };
            string sql = "EXECUTE spCreateCompany @name, @logo, @cvr, @email, @phoneNumber, @active, @note, @addressId, @invoiceAddress";
            var result = _dbConnection.ExecuteScalar(sql, parameter);
            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            return 0;
        }

        public int UpdateCompany(CompanyModel value)
        {
            if (value.Address != null)
            {
                if (value.Address.Id == 0)
                {
                    value.Address.Id = _addressManager.Create(value.Address);
                }
            }
            if (value.InvoiceAddress != null)
            {
                if (value.InvoiceAddress.Id == 0)
                {
                    value.InvoiceAddress.Id = _addressManager.Create(value.InvoiceAddress);
                }
            }
            var parameter = new { id = value.Id, name = value.Name, logo = value.Logo, cvr = value.CVR, email = value.Email, phoneNumber = value.PhoneNumber, active = value.Active, note = value.Note, addressId = ((value.Address == null)?(int?)null:value.Address.Id), invoiceAddress = ((value.InvoiceAddress == null)?(int?)null:value.InvoiceAddress.Id) };
            string sql = "EXECUTE spUpdateCompany @id ,@name, @logo, @cvr, @email, @phoneNumber, @active, @note, @addressId, @invoiceAddress";
            var result = _dbConnection.Execute(sql, parameter);

            return result;
        }
    }
}
