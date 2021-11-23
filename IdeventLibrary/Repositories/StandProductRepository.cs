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
        private static string _baseUrl = "https://localhost:44330/Product/"; // TODO: change to online API
        private static HttpClient _httpClient = new HttpClient();

        public async Task CreateAsync(StandProductModel item)
        {
            string json = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(json.ToString(), UnicodeEncoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync(new Uri(_baseUrl),httpContent);
        }
    }
}
