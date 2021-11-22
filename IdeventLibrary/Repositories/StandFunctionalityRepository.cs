using IdeventLibrary.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
//using Newtonsoft.Json;

namespace IdeventLibrary.Repositories
{
    public class StandFunctionalityRepository : Repository
    {
        //private static string _baseUrl = "https://localhost:44330/byeventid/"; // TODO: change to online API
        private static HttpClient _httpClient = new HttpClient();

        public async Task<List<StandFunctionalityModel>> GetAllFunctionalityByEventId(int id)
        {
            string result = await _httpClient.GetStringAsync(new Uri(_baseUrl + "StandFunctionality/byeventid/" + id));
            List<StandFunctionalityModel> functionList = JsonSerializer.Deserialize<List<StandFunctionalityModel>>(result, Helpers.JsonSerializerOptions);

            return functionList;
        }

    }
}
