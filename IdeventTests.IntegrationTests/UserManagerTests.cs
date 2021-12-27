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
            Assert.Fail("Test not made");
            //_userManager.GetById(); // TODO: insert user data in the InsertTestData script.
        }
        [TestMethod]
        public void UpdateReturnsModelOnSuccess()
        {
            Assert.Fail("Test not made");
        }
        [TestMethod]
        public void UpdateUpdatesAllFields()
        {
            Assert.Fail("Test not made");
        }
    }
}
