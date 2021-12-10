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
    public class ChipGroupManagerTests : TestBase
    {
        private ChipGroupManager _chipGroupManager;
        protected override void TestSpecificInitialization()
        {
            _chipGroupManager = new ChipGroupManager(TestSettings.ConnectionString);
        }

        [TestMethod]
        public void CreateInsertsDataInDatabase()
        {
            Assert.Fail("Test not made");
        }

        [TestMethod]
        public void GetAllByEventIdReturnsList()
        {
            List<ChipGroupModel> chipGroups;
            chipGroups = _chipGroupManager.GetAllByEventId(3); // TODO: check if test data suits this id.

            Assert.IsInstanceOfType(chipGroups, typeof(List<ChipGroupModel>));
        }
    }
}
