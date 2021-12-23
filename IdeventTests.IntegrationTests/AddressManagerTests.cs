using IdeventAPI.Managers;
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
            _addressManager = new AddressManager(TestSettings.ConnectionString);
        }
        [TestMethod]
        public void GetById()
        {
            Assert.Fail("No test made");
        }
    }
}
