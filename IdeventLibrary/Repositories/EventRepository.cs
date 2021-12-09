using IdeventLibrary.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        private static string _baseUrl = $"{Helpers.ApiBaseUrl}/Event";
        private static HttpClient _httpClient = new HttpClient();
        
        public EventRepository()
        {
         
        }

        public async Task<EventModel> Create(EventModel newEvent)
        {
            string json = JsonConvert.SerializeObject(newEvent);
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(new Uri($"{_baseUrl}"), httpContent);
            if (response.IsSuccessStatusCode)
            {
                string newEventAsJson = await _httpClient.GetStringAsync(response.Headers.Location.AbsoluteUri);
                EventModel newItem = JsonConvert.DeserializeObject<EventModel>(newEventAsJson);
                return newItem;
            }
            return null;
        }
        public async Task<List<EventModel>> GetAllAsync()
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl));
            var eventList = JsonConvert.DeserializeObject<List<EventModel>>(jsonContent);
            
            return eventList;
        }
        public async Task<List<EventModel>> GetAllByCompanyIdAsync(int companyId)
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri($"{_baseUrl}/{companyId}"));
            var eventList = JsonConvert.DeserializeObject<List<EventModel>>(jsonContent);

            return eventList;
        }

        public async Task<EventModel> GetByIdAsync(int id)
        {
            string result = await _httpClient.GetStringAsync(new Uri($"{_baseUrl}/{id}") );
            EventModel events = JsonConvert.DeserializeObject<EventModel>(result);
            
            return events;
        }

        
    }
}
