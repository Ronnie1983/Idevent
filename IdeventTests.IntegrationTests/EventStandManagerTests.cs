using IdeventAPI.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeventLibrary.Models;
using System.Data.SqlClient;

namespace IdeventTests.IntegrationTests
{
    [TestClass]
    public class EventStandManagerTests : TestBase
    {
        private EventStandManager _manager;
        protected override void TestSpecificInitialization()
        {
            _manager = new(TestSettings.ConnectionString); 
        }

        [TestMethod]
        public void GetAllReturnsList()
        {
            List<EventStandModel> list =_manager.GetAll();

            Assert.IsNotNull(list);
            Assert.IsInstanceOfType(list, typeof(List<EventStandModel>));
        }
        [TestMethod]
        public void GetByIdReturnsModel()
        {
            EventStandModel stand = _manager.GetById(1);

            Assert.IsNotNull(stand);
            Assert.IsInstanceOfType(stand, typeof(EventStandModel));
        }
        [TestMethod]
        public void CreateAddsStandToDatabase()
        {
            EventStandModel stand = new("My New Stand", new EventModel { Id = 1}, new StandFunctionalityModel { Id = 1});
            int countBefore = _manager.GetAll().Count;
            int countAfter;

            _manager.Create(stand);
            countAfter = _manager.GetAll().Count;

            Assert.AreEqual(countBefore + 1, countAfter);
        }
        [TestMethod]
        public void UpdateModifiesStandNameInDatabaseOnSpecifiedEntry()
        {
            EventStandModel oldStand = _manager.GetById(1);
            EventStandModel newStand = new() 
            {
                Id = oldStand.Id,
                Name = "My New Stand",
                Event = oldStand.Event,
                EventID = oldStand.EventID,
                Functionality = oldStand.Functionality, 
                FunctionalityId = oldStand.FunctionalityId
            };

            int affectedRows =_manager.Update(1, newStand.Name);
            EventStandModel updatedStand = _manager.GetById(1);

            Assert.AreEqual(1, affectedRows);
            Assert.AreNotEqual(oldStand.Name, updatedStand.Name);
        }
        [TestMethod]
        public void DeleteRemovesOneOrZeroEntriesFromDatabase()
        {
            #region Delete data that could prevent deletion of an EventStand.
            try
            {
             
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM ChipContents";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM StandProducts";
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
            #endregion

            int affectedRowsFirstDelete = _manager.Delete(1);
            
            int affectedRowsSecondDelete = _manager.Delete(1);

            Assert.AreEqual(1, affectedRowsFirstDelete);
            Assert.AreEqual(0, affectedRowsSecondDelete);
        }

    }
}
