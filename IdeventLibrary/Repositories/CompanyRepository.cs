using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using IdeventLibrary.Models;
using Newtonsoft.Json;

namespace IdeventLibrary.Repositories
{
    public class CompanyRepository
    {
        private static string _baseUrl = $"{Helpers.ApiBaseUrl}/Company";
        private static HttpClient _httpClient = new HttpClient();
        

        public CompanyRepository()
        {

        }

        public async Task<List<CompanyModel>> GetAllAsync()
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl));
            var eventList = JsonConvert.DeserializeObject<List<CompanyModel>>(jsonContent);
            
            return eventList;
        }

        public async Task<CompanyModel> GetAsync(int id)
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl + "/" + id));
            var company = JsonConvert.DeserializeObject<CompanyModel>(jsonContent);

            return company;
        }

        public async Task<CompanyModel> CreateAsync(CompanyModel item)
        {
            string json = JsonConvert.SerializeObject(item);
            StringContent httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(new Uri(_baseUrl), httpContent);

            if (response.IsSuccessStatusCode)
            {
                string JsonString = await _httpClient.GetStringAsync(response.Headers.Location.AbsoluteUri);
                CompanyModel newItem = JsonConvert.DeserializeObject<CompanyModel>(JsonString);
                return newItem;
            }
            return null;
        }
    }
}
