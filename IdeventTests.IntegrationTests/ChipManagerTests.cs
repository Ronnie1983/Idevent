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
    public class ChipManagerTests
    {
        private ChipManager _chipManager;

        [TestInitialize]
        public void Init()
        {
            _chipManager = new ChipManager(TestSettings.ConnectionString);
        }
        [TestCleanup]
        public void CleanUp()
        {
            
        }
        [TestMethod]
        public void GetAllReturnsList()
        {
            List<ChipModel> chips = _chipManager.GetAll();

            Assert.IsInstanceOfType(chips, typeof(List<ChipModel>));
        }
        //[TestMethod]
        //public void GetByIdThrowsExceptionOnNotFound()
        //{
        //    ChipModel chip = new();
        //    chip = _chipManager.GetById(-1);
        //    Assert.ThrowsException<InvalidOperationException>(() => chip = _chipManager.GetById(-1));
        //}
        [TestMethod]
        public void GetByIdReturnsModel()
        {
            ChipModel chip = _chipManager.GetById(1002); // should be an existing id... Mock or testdatabase needed.

            Assert.IsInstanceOfType(chip, typeof(ChipModel));
        }
    }
}
