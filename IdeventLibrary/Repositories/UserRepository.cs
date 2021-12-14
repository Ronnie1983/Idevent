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
    public class UserRepository
    {
        private static string _baseUrl = $"{Helpers.ApiBaseUrl}/User";
        private static HttpClient _httpClient = new HttpClient();

        private AddressRepository _addressRepository = new AddressRepository();
        private CompanyRepository _companyRepository = new CompanyRepository();

        public UserRepository()
        {
            
        }

        public async Task<UserModel> GetByEmailAsync(string id)
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl + "/" + id));
            var item = JsonConvert.DeserializeObject<UserModel>(jsonContent);
            if (item.Address != null)
            {
                item.Address = await _addressRepository.GetAddressById(item.Address.Id);
            }
            if (item.InvoiceAddress != null)
            {
                item.InvoiceAddress = await _addressRepository.GetAddressById(item.InvoiceAddress.Id);
            }
            if(item.Company != null)
            {
                item.Company = await _companyRepository.GetAsync(item.Company.Id);
            }

            return item;
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
