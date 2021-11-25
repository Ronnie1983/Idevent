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
    public class EventManagerTests
    {
        private EventManager _eventManager;

        [ClassInitialize]
        public void TestClassInit()
        {

        }

        [TestInitialize]
        public void TestInit()
        {
            _eventManager = new EventManager(TestSettings.ConnectionString);
        }
        [TestCleanup]
        public void CleanUp()
        {
            
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
