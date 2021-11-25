﻿using IdeventAPI.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IdeventLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventTests.IntegrationTests
{
    [TestClass]
    public class StandProductManagerTests
    {
        private StandProductManager _manager;

        [TestInitialize]
        public void Init()
        {
            _manager = new StandProductManager();
        }
        [TestCleanup]
        public void CleanUp()
        {
            //_manager.Delete();
        }

        [TestMethod]
        public void GetAllReturnsList()
        {
            List<StandProductModel> products = _manager.GetAll();

            Assert.IsInstanceOfType(products, typeof(List<StandProductModel>));
            Assert.IsTrue(products.Count >= 0);
        }

        [TestMethod]
        public void CreateAddsProductToDatabase()
        {
            StandProductModel productModel = new("My New Product", 5, new EventStandModel { Id = 1 });
            int countBefore = _manager.GetAll().Count;
            int countAfter;

            _manager.Create(productModel);
            countAfter = _manager.GetAll().Count;

            Assert.AreEqual(countBefore + 1, countAfter);
        }
        [TestMethod]
        public void CreateReturnsStandProductId()
        {
            StandProductModel productModel = new("My New Product", 5, new EventStandModel { Id = 1 });

            int output =_manager.Create(productModel);
            StandProductModel productFromOutput = _manager.GetById(output);

            Assert.IsInstanceOfType(productFromOutput, typeof(StandProductModel));
            Assert.AreEqual(productFromOutput.Name, "My New Product");
            Assert.AreEqual(productFromOutput.Value, 5);
        }
    }
}
