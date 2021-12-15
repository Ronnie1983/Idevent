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
    public class ChipManagerTests : TestBase
    {
        private ChipManager _chipManager;

        protected override void TestSpecificInitialization()
        {
            _chipManager = new ChipManager(TestSettings.ConnectionString);
        }

        [TestMethod]
        public void CreateChipWithOnlyCompanyCreatesInDatabase()
        {
            ChipModel newChip = GenerateTestChip();
            int countBeforeCreate = _chipManager.GetAll().Count;

            _chipManager.Create(newChip);
            int countAfterCreate = _chipManager.GetAll().Count;

            Assert.AreEqual(countBeforeCreate+1, countAfterCreate);
        }
        [TestMethod]
        public void CreateChipWithCompanyAndEventCreatesInDatabase()
        {
            ChipModel newChip = GenerateTestChip(true);
            int countBeforeCreate = _chipManager.GetAll().Count;

            _chipManager.Create(newChip);
            int countAfterCreate = _chipManager.GetAll().Count;

            Assert.AreEqual(countBeforeCreate + 1, countAfterCreate);
        }
        [TestMethod]
        public void CreateChipWithCompanyEventAndGroupCreatesInDatabase()
        {
            ChipModel newChip = GenerateTestChip(true, true);
            int countBeforeCreate = _chipManager.GetAll().Count;

            _chipManager.Create(newChip);
            int countAfterCreate = _chipManager.GetAll().Count;

            Assert.AreEqual(countBeforeCreate + 1, countAfterCreate);
        }
        [TestMethod]
        public void GetAllReturnsList()
        {
            List<ChipModel> chips = _chipManager.GetAll();

            Assert.IsInstanceOfType(chips, typeof(List<ChipModel>));
            Assert.IsTrue(chips.Count >= 0);
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
            ChipModel chip = _chipManager.GetById(-1);
            Assert.IsNull(chip);
        }

        [TestMethod]
        public void GetChipByHashedId()
        {
            ChipModel chip = _chipManager.GetByHashedId("urna");

            Assert.IsInstanceOfType(chip, typeof(ChipModel));
        }

        [TestMethod]
        public void GetByHashedIdReturnsNullIfNotFound()
        {
            ChipModel chip = _chipManager.GetByHashedId("findes_ikke");
            Assert.IsNull(chip);
        }

        private ChipModel GenerateTestChip(bool withEvent = false, bool withGroup = false, bool withContent = false)
        {
            CompanyModel company = new CompanyModel(){
                Id = 1,
                Name = "My Company",
                CVR = "12345678",
                PhoneNumber = "+45 55332151",
                Email = "experis@academy.dk",
                Address = new AddressModel()
            };

            ChipModel newChip = new ChipModel();
            newChip.HashedId = "1467262614";
            newChip.ValidFrom = DateTimeOffset.Now;
            newChip.ValidTo = DateTimeOffset.Now.AddDays(1);
            newChip.Company = company;

            if (withEvent)
            {
                newChip.Event = new EventModel() { Id = 1, Name = "Event 101", Company = company};
            }
            if (withGroup && withEvent)
            {
                newChip.Group = new ChipGroupModel() { Id = 1, Name = "My Group"};
            }
            if (withContent)
            {
                newChip.StandProducts.Add(new StandProductModel() { Id = 1, Name = "Product 1",Value=5 ,Amount = 5 });
                newChip.StandProducts.Add(new StandProductModel() { Id = 2, Name = "Andet product",Value=10 ,Amount = 2 });
            }
            return newChip;
        }
    }
}
