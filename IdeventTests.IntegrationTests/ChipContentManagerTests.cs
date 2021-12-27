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
    public class ChipContentManagerTests : TestBase
    {
        ChipContentManager _chipContentManager;
        protected override void TestSpecificInitialization()
        {
           _chipContentManager = ManagerFactory.CreateManagerForTests<ChipContentManager>();
        }

        [TestMethod]
        public void CreateMultipleAddsToDatabase()
        {
            ChipContentModel chipContentRow1 = new ChipContentModel(new StandProductModel() { Id = 1}, 1, 0);
            ChipContentModel chipContentRow2 = new ChipContentModel(new StandProductModel() { Id = 1}, 1, 1);
            List<ChipContentModel> chipContents = new List<ChipContentModel>();
            chipContents.Add(chipContentRow1);
            chipContents.Add(chipContentRow2);

            int countBefore = _chipContentManager.GetAllByChipId(1).Count;
            bool success = _chipContentManager.CreateMultiple(chipContents);
            int countAfter = _chipContentManager.GetAllByChipId(1).Count;

            Assert.AreEqual(countBefore+2, countAfter);
            Assert.AreEqual(true, success);
        }
        [TestMethod]
        public void GetAllByChipIdReturnsStandProductList()
        {
            var list = _chipContentManager.GetAllByChipId(1);

            Assert.IsInstanceOfType(list, typeof(List<StandProductModel>));
            Assert.AreEqual(1, list.Count);
        }
    }
}
