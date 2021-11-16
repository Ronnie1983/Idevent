using IdeventLibrary.Models;
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
        private static string _baseUrl = "https://localhost:44330/Event/"; // TODO: change to online API
        private static HttpClient _httpClient = new HttpClient();

        public async Task<List<EventModel>> GetAllAsync()
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl));
            var eventList = JsonSerializer.Deserialize<List<EventModel>>(jsonContent);

            return eventList;
        }

        
    }
}
