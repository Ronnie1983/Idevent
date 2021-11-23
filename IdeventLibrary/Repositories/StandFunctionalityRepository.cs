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
    public class StandFunctionalityRepository
    {
        private static string _baseUrl = $"{Helpers.ApiBaseUrl}/StandFunctionality";
        private static HttpClient _httpClient = new HttpClient();

        public async Task<List<StandFunctionalityModel>> GetAll()
        {
            string result = await _httpClient.GetStringAsync(new Uri($"{_baseUrl}"));
            List<StandFunctionalityModel> functionList = JsonSerializer.Deserialize<List<StandFunctionalityModel>>(result, Helpers.JsonSerializerOptions);
            if(functionList.Count == 0)
            {
                return new List<StandFunctionalityModel>();
            }
            return functionList;
        }

    }
}
