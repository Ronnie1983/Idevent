using System;
using IdeventLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;


namespace IdeventLibrary.Repositories
{
    public class EventStandRepository
    {
        private static string _baseUrl = $"{Helpers.ApiBaseUrl}/Stand";
        private static HttpClient _httpClient = new HttpClient();
        public async Task<List<EventStandModel>> GetAllAsync()
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl));
            List<EventStandModel> List = JsonConvert.DeserializeObject<List<EventStandModel>>(jsonContent);
            if (string.IsNullOrEmpty(List[0].Name))
            {
                return new List<EventStandModel>();
            }
            return List;
        }

        public async Task<List<EventStandModel>> GetAllByEventIdAsync(int id)
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri( $"{_baseUrl}/byevent/{id}" ));
            List<EventStandModel> List = JsonConvert.DeserializeObject<List<EventStandModel>>(jsonContent);
            if (string.IsNullOrEmpty(List[0].Name))
            {
                return new List<EventStandModel>();
            }
            return List;
        }
        
        public async Task CreateAsync(EventStandModel item)
        {
            JsonSerializerSettings settings = new()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            string json = JsonConvert.SerializeObject(item, settings);
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(new Uri(_baseUrl), httpContent);
        }
    }
}
