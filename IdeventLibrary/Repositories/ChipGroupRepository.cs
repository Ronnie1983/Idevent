using IdeventLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IdeventLibrary.Repositories
{
    public class ChipGroupRepository
    {
        private static string _baseUrl = $"{Helpers.ApiBaseUrl}/ChipGroup";
        private readonly HttpClient _httpClient = new HttpClient();

        public ChipGroupRepository()
        {
        }

        public async Task<ChipGroupModel> CreateAsync(ChipGroupModel newChipGroup)
        {

            string json = JsonConvert.SerializeObject(newChipGroup);
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_baseUrl, httpContent);
            if (response.IsSuccessStatusCode)
            {
                string newItemAsJson = await _httpClient.GetStringAsync(response.Headers.Location.AbsoluteUri);
                ChipGroupModel newItem = JsonConvert.DeserializeObject<ChipGroupModel>(newItemAsJson);
                return newItem;
            }
            return null;
        }
        public async Task<List<ChipGroupModel>> GetAllByEventIdAsync(int eventId)
        {
            string json = await _httpClient.GetStringAsync(new Uri($"{_baseUrl}/EventId/{eventId}"));
            List<ChipGroupModel> deserializedModelList = JsonConvert.DeserializeObject<List<ChipGroupModel>>(json);
            return deserializedModelList;
        }

    }
}
