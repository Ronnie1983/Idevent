using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventTests.IntegrationTests
{
    [TestClass]
    public abstract class BaseTest
    {
        public SqlConnection conn = new SqlConnection(TestSettings.ConnectionString);

        protected abstract void TestSpecificInitialization();
        protected abstract void TestSpecificCleanup();

        [ClassInitialize]
        public void ClassInit()
        {
            // TODO: reset the database on initialization of a test class.
        }
        [ClassCleanup]
        public void ClassCleanup()
        {
            // Close connection
            conn.Dispose();
        }

        [TestInitialize]
        public void Init()
        {
            TestSpecificInitialization();
        }
        [TestCleanup]
        public void CleanUp()
        {
            TestSpecificCleanup();
        }
    }
}
