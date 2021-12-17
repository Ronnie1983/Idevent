using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IdeventLibrary.Repositories
{
    /// <summary>
    /// A class meant for easy access to some static properties.
    /// </summary>
    public static class Helpers
    {
        public static JsonSerializerOptions JsonSerializerOptions
        {
            get => new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }
        /// <summary>
        /// The base URL without "/" at the end.
        /// </summary>
        public static string ApiBaseUrl { get => "https://localhost:44330"; } // TODO: change to online API
        //public static string ApiBaseUrl { get => "https://ideventapi.azurewebsites.net"; } 


    }
}
