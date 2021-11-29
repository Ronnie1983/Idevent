using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventTests.IntegrationTests
{
    [TestClass]
    public abstract class BaseTest
    {
        public SqlConnection conn = new SqlConnection(TestSettings.ConnectionString);
        private static string _sqlServerTestProjectRoot = Path.Combine(Directory.GetCurrentDirectory(), "../../../../");
        private string _scriptFolder = Path.Combine(_sqlServerTestProjectRoot, "IdeventSQLServerTestDB/dbo/Scripts/");

        protected abstract void TestSpecificInitialization();
        protected abstract void TestSpecificCleanup();

        //[ClassInitialize]
        //public void ClassInit()
        //{
           
        //}
        [ClassCleanup]
        public void ClassCleanup()
        {
            // Close connection
            conn.Dispose();
        }

        [TestInitialize]
        public void Init()
        {
            // TODO: reset the database data on initialization of a test
            try
            {
                string insertScriptPath = Path.Combine(_scriptFolder, "Script.InsertTestData.sql");
                string[] insertScriptRaw = File.ReadAllLines(insertScriptPath);
                string insertScript = "";
                for (int i = 0; i < insertScriptRaw.Length; i++)
                {
                    insertScript += insertScriptRaw[i];
                }
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = insertScript;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

            TestSpecificInitialization();
        }
        [TestCleanup]
        public void CleanUp()
        {
            //try
            //{
            //    // TODO: Remove all data from database after test.
            //    SqlCommand cmd = conn.CreateCommand();
            //    cmd.CommandText = "";
            //    conn.Open();
            //    cmd.ExecuteNonQuery();
            //}
            //finally
            //{
            //    conn.Close();
            //}

            TestSpecificCleanup();
        }
    }
}
