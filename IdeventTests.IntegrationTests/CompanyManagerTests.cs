using IdeventAPI.Managers;
using IdeventLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventTests.IntegrationTests
{
    [TestClass]
    public class CompanyManagerTests : TestBase
    {
        private CompanyManager _manager;
        protected override void TestSpecificInitialization()
        {
            _manager = ManagerFactory.CreateManagerForTests<CompanyManager>();
        }

        [TestMethod]
        public void GetAllReturnsList()
        {
            List<CompanyModel> companies = _manager.GetAll();

            Assert.IsInstanceOfType(companies, typeof(List<CompanyModel>));
            Assert.IsTrue(companies.Count >= 0);
        }
        [TestMethod]
        public void GetByIdReturnsModel()
        {
            CompanyModel company = _manager.GetById(1);

            Assert.IsNotNull(company);
            Assert.IsInstanceOfType(company, typeof(CompanyModel));
        }
        [TestMethod]
        public void CreateAddsToDatabaseWithCorrectNameAndReturnsIdOfCreatedCompany()
        {
            CompanyModel companyToAdd = new CompanyModel
            {
                Name = "Inception ApS",
                Email = "noit@inception.com",
                CVR = "12345678",
                Address = new AddressModel(),
                Active = true,
                Logo = "Ikke defineret",
                PhoneNumber = "+45 009998877"
            };
            companyToAdd.Address.Id = 1;
            companyToAdd.InvoiceAddress = companyToAdd.Address;

            int createdId = _manager.Create(companyToAdd);

            Assert.AreEqual(6, createdId);
            CompanyModel newCompanyfromDatabase = _manager.GetById(6);
            Assert.AreEqual(companyToAdd.Name, newCompanyfromDatabase.Name);
        }
        [TestMethod]
        public void UpdateModifiesSpecifiedModel()
        {
            CompanyModel oldCompany = _manager.GetById(1);
            string newEmail = "esdeath@freezing.cold";
            AddressModel newAddress = new AddressModel("Trade District 55", "Stormwind", "Eastern Kingdoms", "40K23") { Id = oldCompany.Address.Id};
            CompanyModel newCompany = new CompanyModel()
            {
                Id = oldCompany.Id,
                Name = oldCompany.Name,
                Email = newEmail,
                CVR = oldCompany.CVR,
                Address = newAddress,
                InvoiceAddress = oldCompany.InvoiceAddress,
                PhoneNumber = oldCompany.PhoneNumber,
                Active = oldCompany.Active,
                Logo = oldCompany.Logo,
                Note = oldCompany.Note, 
            };

            int affectedRows = _manager.UpdateCompany(newCompany);
            CompanyModel updatedCompany = _manager.GetById(1);


            Assert.AreEqual(1, affectedRows);
            Assert.AreEqual(oldCompany.Id, updatedCompany.Id);
            Assert.AreEqual(oldCompany.Name, updatedCompany.Name);
            Assert.AreNotEqual(oldCompany.Email, updatedCompany.Email);
            Assert.AreNotEqual(oldCompany.Address.StreetAddress, updatedCompany.Address.StreetAddress);

        }
    }
}
