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
    public class EventRepository : Repository
    {
        //private static string _baseUrl = "https://localhost:44330/Event/"; // TODO: change to online API
        private static HttpClient _httpClient = new HttpClient();
        
        public EventRepository()
        {
         
        }

        public async Task<List<EventModel>> GetAllAsync()
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl + "Event/"));
            var eventList = JsonSerializer.Deserialize<List<EventModel>>(jsonContent, Helpers.JsonSerializerOptions);
            if (string.IsNullOrEmpty(eventList[0].Name))
            {
                throw new Exception("JsonSerialiser didn't serialise well enough...");
            }
            return eventList;
        }

        public async Task<EventModel> GetByIdAsync(int id)
        {
            string result = await _httpClient.GetStringAsync(new Uri(_baseUrl) + "Event/" + $"{id}");
            EventModel events = JsonSerializer.Deserialize<EventModel>(result, Helpers.JsonSerializerOptions);
            
            return events;
        }

        
    }
}
