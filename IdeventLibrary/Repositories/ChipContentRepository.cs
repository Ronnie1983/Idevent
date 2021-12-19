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
    public class ChipContentRepository
    {


        private static string _baseUrl = $"{Helpers.ApiBaseUrl}/ChipContent";
        private static HttpClient _httpClient = new HttpClient();

        public async Task<bool> CreateAsync(StandProductModel standProduct, int chipId, int chipGroupId)
        {
            // Not implemented in the API.
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
                if (standProduct.Amount > 0)
                {
                    chipContents.Add(new ChipContentModel(standProduct, chipId, chipGroupId));
                }
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

        public async Task<bool> CreateAndUpdateMultipleAsync(List<StandProductModel> standProducts, int chipId)
        {
            bool success = false;
            List<ChipContentModel> chipContents = new List<ChipContentModel>();
            foreach (StandProductModel standProduct in standProducts)
            {
                if (standProduct.Amount != 0)
                {
                    chipContents.Add(new ChipContentModel(standProduct, chipId));
                }
            }

            string json = JsonConvert.SerializeObject(chipContents);
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(new Uri($"{_baseUrl}/MultipleCreateAndUpdate"), httpContent);

            if (response.IsSuccessStatusCode)
            {
                success = true;
                return success;
            }
            return success;

        }

        public async Task<List<StandProductModel>> GetAllContentByStandIdAndChipIdAsync(int chipId, int standId)
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl +"/Chip/"+ chipId +"/Stand/"+ standId));
            List<StandProductModel> List = JsonConvert.DeserializeObject<List<StandProductModel>>(jsonContent);

            return List;
        }
    }
}
