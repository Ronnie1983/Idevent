using System;
using IdeventLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;


namespace IdeventLibrary.Repositories
{
    public class EventStandRepository
    {
        private static string _baseUrl = $"{Helpers.ApiBaseUrl}/Stand";
        private static HttpClient _httpClient = new HttpClient();
        public async Task<List<EventStandModel>> GetAllAsync()
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl));
            var List = JsonSerializer.Deserialize<List<EventStandModel>>(jsonContent, Helpers.JsonSerializerOptions);
            if (string.IsNullOrEmpty(List[0].Name))
            {
                throw new Exception("JsonSerialiser didn't serialise well enough...");
            }
            return List;
        }

        public async Task<List<EventStandModel>> GetAllByEventIdAsync(int id)
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri( $"{_baseUrl}/byevent/{id}" ));
            var List = JsonSerializer.Deserialize<List<EventStandModel>>(jsonContent, Helpers.JsonSerializerOptions);
            if (string.IsNullOrEmpty(List[0].Name))
            {
                throw new Exception("JsonSerialiser didn't serialise well enough...");
            }
            return List;
        }
    }
}
