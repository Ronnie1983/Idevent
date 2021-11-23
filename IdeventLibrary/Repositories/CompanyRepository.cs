using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using IdeventLibrary.Models;
using System.Text.Json;

namespace IdeventLibrary.Repositories
{
    public class CompanyRepository
    {
        private static string _baseUrl = "https://localhost:44330/Company/"; // TODO: change to online API
        private static HttpClient _httpClient = new HttpClient();

        public CompanyRepository()
        {

        }

        public async Task<List<CompanyModel>> GetAllAsync()
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl));
            var eventList = JsonSerializer.Deserialize<List<CompanyModel>>(jsonContent, Helpers.JsonSerializerOptions);
            if (string.IsNullOrEmpty(eventList[0].Name))
            {
                throw new Exception("JsonSerialiser didn't serialise well enough...");
            }
            return eventList;
        }
    }
}
