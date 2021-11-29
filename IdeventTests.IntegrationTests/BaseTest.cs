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
                string insertScript = ReadSqlScript("Script.InsertTestData.sql");
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = insertScript;
                conn.Open();
                int affectedRows = cmd.ExecuteNonQuery();
                if(affectedRows == -1)
                {
                    Assert.Fail("The Script.InsertTestData.sql was unsuccessfully run in TestBase.cs");
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
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
            try
            {
                // TODO: Remove all data from database after test.
                string deleteAllScript = ReadSqlScript("Script.DeleteAllTableData.sql");
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = deleteAllScript;
                conn.Open();
                int affectedRows = cmd.ExecuteNonQuery(); // affectedRows variable just for debugging.
                if (affectedRows == -1)
                {
                    Assert.Fail("The Script.DeleteAllTableData.sql was unsuccessfully run in TestBase.cs");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            TestSpecificCleanup();
        }

        /// <summary>
        /// Reads all lines from a file and returns a string with the read data.
        /// </summary>
        /// <param name="scriptFileName">The name of the file (including extension, e.g. .sql or .txt)</param>
        /// <returns></returns>
        private string ReadSqlScript(string scriptFileName)
        {
            string scriptPath = Path.Combine(_scriptFolder, scriptFileName);
            string[] linesInFile = File.ReadAllLines(scriptPath);
           
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < linesInFile.Length; i++)
            {
                sb.AppendLine(linesInFile[i]);
                
            }
            string script = sb.ToString();

            return script;
        }
    }
}
