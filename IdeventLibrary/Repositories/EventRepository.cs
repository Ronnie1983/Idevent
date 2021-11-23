using IdeventLibrary.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IdeventLibrary.Repositories
{
    public class EventRepository
    {
        private static string _baseUrl = $"{Helpers.ApiBaseUrl}/Event"; // TODO: change to online API
        private static HttpClient _httpClient = new HttpClient();
        
        public EventRepository()
        {
         
        }

        public async Task<List<EventModel>> GetAllAsync()
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl));
            var eventList = JsonSerializer.Deserialize<List<EventModel>>(jsonContent, Helpers.JsonSerializerOptions);
            
            return eventList;
        }

        public async Task<EventModel> GetByIdAsync(int id)
        {
            string result = await _httpClient.GetStringAsync(new Uri($"{_baseUrl}/{id}") );
            EventModel events = JsonSerializer.Deserialize<EventModel>(result, Helpers.JsonSerializerOptions);
            
            return events;
        }

        
    }
}
