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
    public abstract class TestBase
    {
        protected SqlConnection conn = new SqlConnection(TestSettings.ConnectionString);
        private static string _sqlServerTestProjectRoot = Path.Combine(Directory.GetCurrentDirectory(), "../../../../");
        private string _scriptFolder = Path.Combine(_sqlServerTestProjectRoot, "IdeventSQLServerTestDB/dbo/Scripts/");

        /// <summary>
        /// You can extend the initialisation that is run before each Test Method with this method.
        /// </summary>
        protected abstract void TestSpecificInitialization();
        /// <summary>
        /// You can extend the cleanup that is run after each Test Method here.
        /// </summary>
        protected virtual void TestSpecificCleanup()
        {
            // Nothing by default.
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
            string createTablesFileName = "Script.CreateTables.sql";
            string createTablesScript = ReadSqlScript(createTablesFileName);
            ExecuteNonQuery(createTablesScript, createTablesFileName);

            string insertScriptFileName = "Script.InsertTestData.sql";
            string insertScript = ReadSqlScript(insertScriptFileName);
            ExecuteNonQuery(insertScript, insertScriptFileName);

            TestSpecificInitialization();
        }

        [TestCleanup]
        public void CleanUp()
        {
            string dropTablesFileName = "Script.DropAllTables.sql";
            string dropTablesScript = ReadSqlScript(dropTablesFileName);
            ExecuteNonQuery(dropTablesScript, dropTablesFileName);

            
            TestSpecificCleanup();
        }

        /// <summary>
        /// Executes a non-query script.
        /// </summary>
        /// <param name="sqlScript">The 'non-query' SQL script to execute</param>
        /// <param name="fileName">An identifying name for the script (for debugging purposes)</param>
        private void ExecuteNonQuery(string sqlScript, string identifyingNameForScript)
        {
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlScript;
                conn.Open();
                int affectedRows = cmd.ExecuteNonQuery(); // affectedRows variable just for debugging.
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"The {identifyingNameForScript} was unsuccessfully run in TestBase.cs");
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// Executes a non-query script.
        /// </summary>
        /// <param name="fileName">Name of the file to execute from the IdeventSQLServerTestDB Scripts folder (including extension)</param>
        private void ExecuteNonQuery(string fileName)
        {
            try
            {
                string sqlScript = ReadSqlScript(fileName);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlScript;
                conn.Open();
                int affectedRows = cmd.ExecuteNonQuery(); // affectedRows variable just for debugging.
               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"The {fileName} was unsuccessfully run in TestBase.cs");
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Reads all lines from a file and returns a string with the read data.
        /// The file is assumed to originate from the IdeventSQLServerTestDB Scripts folder.
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
