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
    public class ChipContentRepository
    {
        private static string _baseUrl = $"{Helpers.ApiBaseUrl}/ChipContent";
        private static HttpClient _httpClient = new HttpClient();

        public async Task<bool> CreateAsync(StandProductModel standProduct, int chipId, int chipGroupId)
        {
            bool success = false;
            ChipContentModel chipContentModel = new ChipContentModel(standProduct, chipId, chipGroupId);

            string json = JsonConvert.SerializeObject(chipContentModel);
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(new Uri(_baseUrl), httpContent);

            if (response.IsSuccessStatusCode)
            {
                success = true;
                return success;
            }
            return success;
        }
        public async Task<bool> CreateMultipleAsync(List<StandProductModel> standProducts, int chipId, int chipGroupId)
        {
            bool success = false;
            List<ChipContentModel> chipContents = new List<ChipContentModel>();
            foreach (StandProductModel standProduct in standProducts)
            {
                chipContents.Add(new ChipContentModel(standProduct, chipId, chipGroupId));
            }

            string json = JsonConvert.SerializeObject(chipContents);
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(new Uri($"{_baseUrl}/Multiple"), httpContent);

            if (response.IsSuccessStatusCode)
            {
                success = true;
                return success;
            }
            return success;
        }
    }
}
