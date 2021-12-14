using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bunit;

namespace IdeventTests
{
    [TestClass]
    public class TestBase
    {
        protected Bunit.TestContext _testContext;

        [TestInitialize]
        public void TestInit()
        {
            _testContext = new Bunit.TestContext();
        }
        [TestCleanup]
        public void TestCleanup()
        {
            _testContext?.Dispose();
        }
        
    }
}
