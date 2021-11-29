using IdeventAPI.Managers;
using IdeventLibrary.Models;
using IdeventTests.IntegrationTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventTests
{
    [TestClass]
    public class ChipManagerTests : BaseTest
    {
        private ChipManager _chipManager;

        protected override void TestSpecificInitialization()
        {
            _chipManager = new ChipManager(TestSettings.ConnectionString);
        }
        protected override void TestSpecificCleanup()
        {
            // No specific cleanup yet.
        }

        [TestMethod]
        public void GetAllReturnsList()
        {
            List<ChipModel> chips = _chipManager.GetAll();

            Assert.IsInstanceOfType(chips, typeof(List<ChipModel>));
        }
        [TestMethod]
        public void GetByIdReturnsModel()
        {
            ChipModel chip = _chipManager.GetById(1);

            Assert.IsInstanceOfType(chip, typeof(ChipModel));
        }
        [TestMethod]
        public void GetByIdReturnsNullIfNotFound()
        {
            ChipModel chip = new();
            chip = _chipManager.GetById(-1);
            Assert.IsNull(chip);
        }


    }
}
