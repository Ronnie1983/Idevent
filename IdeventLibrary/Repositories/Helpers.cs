using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IdeventLibrary.Repositories
{
    public class Helpers
    {
        public static JsonSerializerOptions JsonSerializerOptions
        {
            get => new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }


    }
}
