using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using IdeventLibrary.Models;
//using System.Text.Json;
using Newtonsoft.Json;

namespace IdeventLibrary.Repositories
{
    public class AddressRepository
    {
        private static string _baseUrl = $"{Helpers.ApiBaseUrl}/Address";
        private static HttpClient _httpClient = new HttpClient();

        public async Task<AddressModel> CreateAsync(AddressModel item)
        {
            string json = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(new Uri(_baseUrl), httpContent);

            if (response.IsSuccessStatusCode)
            {
                string JsonString = await _httpClient.GetStringAsync(response.Headers.Location.AbsoluteUri);
                AddressModel newItem = JsonConvert.DeserializeObject<AddressModel>(JsonString);
                return newItem;
            }
            return null;
        }
    }
}
