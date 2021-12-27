using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using IdeventLibrary.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdeventLibrary.Repositories
{
    public class UserRepository
    {
        private static string _baseUrl = $"{Helpers.ApiBaseUrl}/User";
        private static HttpClient _httpClient = new HttpClient();

        private AddressRepository _addressRepository = new AddressRepository();
        private CompanyRepository _companyRepository = new CompanyRepository();
        private UserManager<UserModel> _userManager;

        public UserRepository()
        {
            // Only here for testing purposes. (Simulates a fake UserRepository without the need for UserManager)
        }
        public UserRepository(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }
        public async Task<List<UserModel>> GetAllAsync()
        {
            var users = await Task.Run(async () =>
            {
                List<UserModel> tempUsers = _userManager.Users.ToList();

                // Fetch custom data (non-identity)
                string json = await _httpClient.GetStringAsync(new Uri($"{_baseUrl}/CustomData"));
                Dictionary<string, UserModel> moreUserData = JsonConvert.DeserializeObject<Dictionary<string, UserModel>>(json);
                
                List<UserModel> output;
                foreach (var user in tempUsers)
                {
                    await SetUserRole(user);
                    // Combine identity & custom data
                    moreUserData.TryGetValue(user.Id, out UserModel tempUser);
                    user.Address = tempUser.Address;
                    user.InvoiceAddress = tempUser.InvoiceAddress;
                    user.Company = tempUser.Company;
                }
                output = tempUsers;
                return output;
            });
           
            return users;
        }
        public async Task<UserModel> GetByClaim(ClaimsPrincipal claim)
        {
            UserModel user = await _userManager.GetUserAsync(claim);

            await SetUserRole(user);

            return user;
        }

        public async Task<UserModel> GetByEmailAsync(string email)
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl + "/email/" + email));
            var item = JsonConvert.DeserializeObject<UserModel>(jsonContent);
            if (item.Address != null)
            {
                item.Address = await _addressRepository.GetAddressById(item.Address.Id);
            }
            if (item.InvoiceAddress != null)
            {
                item.InvoiceAddress = await _addressRepository.GetAddressById(item.InvoiceAddress.Id);
            }
            if (item.Company != null)
            {
                item.Company = await _companyRepository.GetAsync(item.Company.Id);
            }

            return item;
        }

        public async Task<UserModel> GetUserById(string id)
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri($"{_baseUrl}/{id}"));
            UserModel user = JsonConvert.DeserializeObject<UserModel>(jsonContent);
            await SetUserRole(user);
            return user;
        }

        public async Task<UserModel> UpdateAsync(UserModel updatedModel, string oldRole)
        {
            string json = JsonConvert.SerializeObject(updatedModel);
            StringContent httpsContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(new Uri(_baseUrl), httpsContent);
            await UpdateRoleAsync(updatedModel, oldRole);
            if (response.IsSuccessStatusCode)
            {
                return updatedModel;
            }
            return null;
        }
        public async Task UpdateRoleAsync(UserModel updatedModel, string oldRole)
        {
            await _userManager.AddToRoleAsync(updatedModel, updatedModel.Role);
            await _userManager.RemoveFromRoleAsync(updatedModel, oldRole);
        }
        private async Task SetUserRole(UserModel user)
        {
            IList<string> userRoles = await _userManager.GetRolesAsync(user);
            user.Role = userRoles.First();
        }
    }
}
