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
    public class UserRepository
    {
        private static string _baseUrl = $"{Helpers.ApiBaseUrl}/User";
        private static HttpClient _httpClient = new HttpClient();

        public UserRepository()
        {

        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl));
            var profilList = JsonConvert.DeserializeObject<List<UserModel>>(jsonContent);
            
            return profilList;
        }

        public async Task<UserModel> GetUserById(string id)
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl + "/" + id));
            var user = JsonConvert.DeserializeObject<UserModel>(jsonContent);

            return user;
        }

        //public async Task<UserModel> UpdateAsync(UserModel item)
        //{
        //    string json = JsonConvert.SerializeObject(item);
        //    StringContent httpsContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
        //    var resonse = await _httpClient.PutAsync(new Uri(_baseUrl + "/" + item.Id), httpsContent);



        //    return null;
        //}


    }
}
