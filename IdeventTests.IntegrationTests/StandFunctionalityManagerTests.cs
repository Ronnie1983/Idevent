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
    public class StandFunctionalityManagerTests : BaseTest
    {
        private StandFunctionalityManager _manager;

        protected override void TestSpecificInitialization()
        {
            _manager = new StandFunctionalityManager();
        }

        protected override void TestSpecificCleanup()
        {
            throw new NotImplementedException();
        }
    }
}
