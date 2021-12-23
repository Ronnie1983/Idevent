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
    }
}
