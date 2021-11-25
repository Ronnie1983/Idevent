using IdeventAPI.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        }
        [TestMethod]
        public void CreateReturnsIdOfCreatedProduct()
        {
            //_manager.Create
        }
    }
}
