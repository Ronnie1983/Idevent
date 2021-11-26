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
    public class EventManagerTests : BaseTest
    {
        private EventManager _eventManager;
        protected override void TestSpecificInitialization()
        {
            _eventManager = new EventManager(TestSettings.ConnectionString);
        }

        protected override void TestSpecificCleanup()
        {
            // No test specific cleanup atm.
        }

        [TestMethod]
        public void GetAllReturnsList()
        {
            List<EventModel> events = new();
            events = _eventManager.GetAll();

            Assert.IsInstanceOfType(events, typeof(List<EventModel>));
        }


    }
}
