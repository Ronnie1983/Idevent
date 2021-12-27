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
            _chipGroupManager = ManagerFactory.CreateManagerForTests<ChipGroupManager>();
        }

        [TestMethod]
        public void CreateInsertsDataInDatabase()
        {
            ChipGroupModel newChipGroup = new ChipGroupModel("My Group", 2);
            //int beforeCreate = _chipGroupManager = _chipGroupManager.GetAll();

            int idOfCreatedGroup = _chipGroupManager.Create(newChipGroup);
            //int afterCreate = _chipGroupManager.GetAll();

            //Assert.AreEqual(beforeCreate + 1, afterCreate);
            Assert.AreEqual(idOfCreatedGroup, 6);
        }

        [TestMethod]
        public void GetAllByEventIdReturnsList()
        {
            List<ChipGroupModel> chipGroups;
            chipGroups = _chipGroupManager.GetAllByEventId(3); // TODO: check if test data suits this id.

            Assert.IsInstanceOfType(chipGroups, typeof(List<ChipGroupModel>));
        }
        [TestMethod]
        public void GetByIdReturnsChipGroup()
        {
            ChipGroupModel chipGroup = _chipGroupManager.GetById(3);

            Assert.IsInstanceOfType(chipGroup, typeof(ChipGroupModel));
        }
    }
}
