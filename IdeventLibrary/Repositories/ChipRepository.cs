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
    public class ChipRepository
    {
        private string _baseUrl = $"{Helpers.ApiBaseUrl}/Chip";
        private HttpClient _httpClient = new HttpClient();
        
        public ChipRepository()
        {         
        }

        public async Task<List<ChipModel>> GetAllAsync()
        {
            try
            {
                string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl));
                var chipList = JsonSerializer.Deserialize<List<ChipModel>>(jsonContent, Helpers.JsonSerializerOptions);
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
                ChipModel chip = JsonSerializer.Deserialize<ChipModel>(jsonContent, Helpers.JsonSerializerOptions);

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
                string jsonContent = await _httpClient.GetStringAsync(new Uri($"{_baseUrl}/Secret/{id}"));
                if (string.IsNullOrEmpty(jsonContent))
                {
                    return null;
                }
                ChipModel chip = JsonSerializer.Deserialize<ChipModel>(jsonContent, Helpers.JsonSerializerOptions);

                return chip;
            }
            catch
            {
                return null;
            }
        }


    }
}
