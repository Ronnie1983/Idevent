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
            string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl));
            var chipList = JsonSerializer.Deserialize<List<ChipModel>>(jsonContent, Helpers.JsonSerializerOptions);
            if (string.IsNullOrEmpty(chipList[0].Company.Name))
            {
                throw new Exception("JsonSerialiser didn't serialise well enough...");
            }
            return chipList;
        }
        public async Task<ChipModel> GetById(int id)
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri($"{_baseUrl}/{id}"));
            ChipModel chip = JsonSerializer.Deserialize<ChipModel>(jsonContent, Helpers.JsonSerializerOptions);
            if (string.IsNullOrWhiteSpace(chip.Company.Name))
            {
                throw new Exception("JsonSerialiser didn't serialise well enough...");
            }
            return chip;
        }


    }
}
