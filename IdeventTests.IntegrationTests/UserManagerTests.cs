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
    public class UserManagerTests : TestBase
    {
        private UserManager _userManager;
        protected override void TestSpecificInitialization()
        {
            _userManager = ManagerFactory.CreateManagerForTests<UserManager>();
        }
        [TestMethod]
        public void GetAllCustomDataReturnsDictionary()
        {
            Dictionary<string, UserModel> output = _userManager.GetAllCustomData();

            Assert.IsNotNull(output);
            Assert.IsInstanceOfType(output, typeof(Dictionary<string, UserModel>));
        }
        [TestMethod]
        public void GetByIdReturnsModel()
        {
            UserModel user = _userManager.GetById("5E99B1B2-BA7E-9B2E-2963-50CCB71AD64E");
            Assert.IsNotNull(user);
            Assert.IsInstanceOfType(user, typeof(UserModel));
        }
        //[TestMethod]
        //public void UpdateReturnsTrueOnSuccess()
        //{
        //    Assert.Fail("Test not made");
        //}
        [TestMethod]
        public void UpdateUpdatesAllFields()
        {
            UserModel user = _userManager.GetById("5E99B1B2-BA7E-9B2E-2963-50CCB71AD64E");
            user.UserName = "Mads";
            user.Email = "Mads@Mads.dk";
            user.PhoneNumber = "12345678";
            user.Company.Id = 1;
            user.Address.Id = 1;
            user.Address.StreetAddress = "Holmen 4";
            user.Address.Country = "DK";
            user.Address.City = "CPH";
            user.Address.PostalCode = "2000";


            bool success = _userManager.Update(user);
            Assert.AreEqual(true,success);

            UserModel updatedUser = _userManager.GetById("5E99B1B2-BA7E-9B2E-2963-50CCB71AD64E");

            Assert.AreEqual(user.UserName, updatedUser.UserName);
            Assert.AreEqual(user.Email, updatedUser.Email);
            Assert.AreEqual(user.PhoneNumber, updatedUser.PhoneNumber);
            Assert.AreEqual(user.Company.Id, updatedUser.Company.Id);
            Assert.AreEqual(user.Address.Id, updatedUser.Address.Id);
            Assert.AreEqual(user.Address.StreetAddress, updatedUser.Address.StreetAddress);
            Assert.AreEqual(user.Address.Country, updatedUser.Address.Country);
            Assert.AreEqual(user.Address.City, updatedUser.Address.City);
            Assert.AreEqual(user.Address.PostalCode, updatedUser.Address.PostalCode);
            
        }
    }
}
