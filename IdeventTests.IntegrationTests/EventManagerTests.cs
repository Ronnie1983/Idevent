﻿using IdeventAPI.Managers;
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
    public class EventManagerTests : TestBase
    {
        private EventManager _eventManager;
        protected override void TestSpecificInitialization()
        {
            _eventManager = new EventManager(TestSettings.ConnectionString);
        }

        [TestMethod]
        public void CreateAddsEventToDatabase()
        {
            EventModel newEvent = new EventModel()
            {
                Name = "My event",
                Company = new CompanyModel() { Id = 1}
            };
            int countBefore = _eventManager.GetAll().Count;
            int countAfter;

            _eventManager.Create(newEvent);
            countAfter = _eventManager.GetAll().Count;

            Assert.AreEqual(countBefore + 1, countAfter);
        }
        [TestMethod]
        public void GetAllReturnsList()
        {
            List<EventModel> events;
            events = _eventManager.GetAll();

            Assert.IsInstanceOfType(events, typeof(List<EventModel>));
        }
        [TestMethod]
        public void GetByIdReturnsModel()
        {
            EventModel model = _eventManager.GetById(1);
            Assert.IsNotNull(model);
            Assert.IsInstanceOfType(model, typeof(EventModel));
        }
        [TestMethod]
        public void GetAllByCompanyId()
        {
            List<EventModel> events;
            events = _eventManager.GetAllByCompanyId(1);

            Assert.IsInstanceOfType(events, typeof(List<EventModel>));
        }


    }
}
