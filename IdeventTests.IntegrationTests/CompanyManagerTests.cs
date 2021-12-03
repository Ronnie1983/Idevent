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
            _manager = new CompanyManager();
        }

        [TestMethod]
        public void GetAllReturnsList()
        {
            List<CompanyModel> companies = _manager.GetAll();

            Assert.IsInstanceOfType(companies, typeof(List<CompanyModel>));
            Assert.IsTrue(companies.Count >= 0);
        }

    }
}
