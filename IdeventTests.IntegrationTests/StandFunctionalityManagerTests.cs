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
    public class StandFunctionalityManagerTests
    {
        private StandFunctionalityManager _manager;
        [TestInitialize]
        public void Init()
        {
            _manager = new StandFunctionalityManager();
        }
        [TestCleanup]
        public void CleanUp()
        {
            
        }
        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
