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
    public class EventManagerTests : TestBase
    {
        private EventManager _eventManager;
        protected override void TestSpecificInitialization()
        {
            _eventManager = new EventManager(TestSettings.ConnectionString);
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
