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
    public class AddressManagerTests : TestBase
    {
        private AddressManager _addressManager;
        protected override void TestSpecificInitialization()
        {
            _addressManager = ManagerFactory.CreateManagerForTests<AddressManager>();
        }

        [TestMethod]
        public void CreateReturnsIdAndCreatesModelWithExpectedValues()
        {
            // Arrange
            AddressModel address = new AddressModel("Trade district 552", "Capitol of Stormwind", "Kingdom of Stormwind", "N2010");

            // Act
            int createdAddressId = _addressManager.Create(address);
            AddressModel createdAddress = _addressManager.GetById(createdAddressId);

            // Assert
            Assert.IsNotNull(createdAddress);
            Assert.AreEqual(address.StreetAddress, createdAddress.StreetAddress);
            Assert.AreEqual(address.City, createdAddress.City);
            Assert.AreEqual(address.Country, createdAddress.Country);
            Assert.AreEqual(address.PostalCode, createdAddress.PostalCode);
        }

        [TestMethod]
        public void GetByIdReturnsModel()
        {
            AddressModel address = _addressManager.GetById(2);

            Assert.IsNotNull(address);
            Assert.IsInstanceOfType(address, typeof(AddressModel));
        }
    }
}
