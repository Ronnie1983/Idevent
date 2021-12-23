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
    public class StandFunctionalityManagerTests : TestBase
    {
        private StandFunctionalityManager _standFunctionalityManager;

        protected override void TestSpecificInitialization()
        {
            _standFunctionalityManager = ManagerFactory.CreateManagerForTests<StandFunctionalityManager>();
        }

        [TestMethod]
        public void GetAllReturnsList()
        {
            List<StandFunctionalityModel> functionalities = _standFunctionalityManager.GetAll();
            
            Assert.IsInstanceOfType(functionalities, typeof(List<StandFunctionalityModel>));
        }
        [TestMethod]
        public void GetByIdReturnsModel()
        {
            StandFunctionalityModel functionality = _standFunctionalityManager.GetById(1);

            Assert.IsNotNull(functionality);
            Assert.IsInstanceOfType(functionality, typeof(StandFunctionalityModel));
        }
        [TestMethod]
        public void CreateInsertsInDatabase()
        {
            int beforeCount = _standFunctionalityManager.GetAll().Count;

            _standFunctionalityManager.Create(new StandFunctionalityModel("Default"));
            int afterCount = _standFunctionalityManager.GetAll().Count;

            Assert.AreEqual(beforeCount+1, afterCount);
        }
    }
}
