using System;

namespace IdeventAPI.Managers
{
    /// <summary>
    /// A class meant for easy access to some static properties.
    /// </summary>
    public static class Helpers
    {
        public static string ConnectionString = Environment.GetEnvironmentVariable("ConnectionStringIdevent");
    }
}
