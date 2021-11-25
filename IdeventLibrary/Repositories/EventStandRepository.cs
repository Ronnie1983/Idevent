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
         
            return List;
        }

        public async Task<List<EventStandModel>> GetAllByEventIdAsync(int id)
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri( $"{_baseUrl}/byevent/{id}" ));
            List<EventStandModel> List = JsonConvert.DeserializeObject<List<EventStandModel>>(jsonContent);
            
            return List;
        }
        
        public async Task<EventStandModel> CreateAsync(EventStandModel item)
        {
            JsonSerializerSettings settings = new()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            string json = JsonConvert.SerializeObject(item, settings);
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(new Uri(_baseUrl), httpContent);

            if (response.IsSuccessStatusCode)
            {
                string JsonString = await _httpClient.GetStringAsync(response.Headers.Location.AbsoluteUri);
                EventStandModel newItem = JsonConvert.DeserializeObject<EventStandModel>(JsonString);
                return newItem;
            }
            return null;
        }

        public async Task UpdateNameAsync(EventStandModel item, string value)
        {
            string json = JsonConvert.SerializeObject(value);
            StringContent httpContent = new StringContent(json, Encoding.UTF8 , "application/json");

            var response = await _httpClient.PutAsync($"{_baseUrl}/updatename/{item.Id}", httpContent);
        }
        
        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            return response;
        }
        
    }
}
