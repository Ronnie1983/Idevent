using System;

namespace IdeventLibrary
{
    /// <summary>
    /// Contains static helper properties, such as the connectionstring.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// ConnectionString to the database. Fetched from an environment variable.
        /// </summary>
        public static string ConnectionString { get => Environment.GetEnvironmentVariable("SQLCONNSTR_IdeventConnectionString"); }
    }
}
