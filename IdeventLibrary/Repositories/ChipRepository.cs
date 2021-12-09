using IdeventLibrary.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace IdeventLibrary.Repositories
{
    public class ChipRepository
    {
        private string _baseUrl = $"{Helpers.ApiBaseUrl}/Chip";
        private HttpClient _httpClient = new HttpClient();
        
        public ChipRepository()
        {         
        }

        public async Task<ChipModel> CreateAsync(ChipModel newChipModel)
        {
            string json = JsonConvert.SerializeObject(newChipModel);
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(new Uri($"{_baseUrl}"), httpContent);
            string test = "";
            if (response.IsSuccessStatusCode)
            {
                string newItemAsJson = await _httpClient.GetStringAsync(response.Headers.Location.AbsoluteUri);
                ChipModel newItem = JsonConvert.DeserializeObject<ChipModel>(newItemAsJson);
                return newItem;
            }
            return null;
        }

        public async Task<List<ChipModel>> GetAllAsync()
        {
            try
            {
                string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl));
                var chipList = JsonConvert.DeserializeObject<List<ChipModel>>(jsonContent);
                return chipList;
            }
            catch
            {
                return new List<ChipModel>();
            }
        }
        public async Task<ChipModel> GetById(int id)
        {

            try
            {
                string jsonContent = await _httpClient.GetStringAsync(new Uri($"{_baseUrl}/{id}"));
                ChipModel chip = JsonConvert.DeserializeObject<ChipModel>(jsonContent);

                return chip;
            }
            catch
            {
                return null;
            }

            
        }

        public async Task<ChipModel> GetBySecretId(string id)
        {
            try
            {
                string jsonContent = await _httpClient.GetStringAsync(new Uri($"{_baseUrl}/HashedId/{id}"));
                if (string.IsNullOrEmpty(jsonContent))
                {
                    return null;
                }
                ChipModel chip = JsonConvert.DeserializeObject<ChipModel>(jsonContent);

                return chip;
            }
            catch
            {
                return null;
            }
        }


    }
}
