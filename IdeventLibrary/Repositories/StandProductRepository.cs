using IdeventLibrary.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IdeventLibrary.Repositories
{
    public class StandProductRepository
    {
        private static string _baseUrl = $"{Helpers.ApiBaseUrl}/Product"; // TODO: change to online API
        private static HttpClient _httpClient = new HttpClient();

        public async Task<StandProductModel> CreateAsync(StandProductModel item)
        {
            string json = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync(new Uri(_baseUrl),httpContent);

            if (response.IsSuccessStatusCode)
            {
                string JsonString = await _httpClient.GetStringAsync(response.Headers.Location.AbsoluteUri);
                StandProductModel newItem = JsonConvert.DeserializeObject<StandProductModel>(JsonString);
                return newItem;
            }
            return null;
        }

        public async Task<List<StandProductModel>> GetAllProductsByStandIdAsync(int id)
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl+ "/standid/"+id));
            List<StandProductModel> List = JsonConvert.DeserializeObject<List<StandProductModel>>(jsonContent);
            
            return List;
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            return response;
        }
    }
}
