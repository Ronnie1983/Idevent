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

        public async Task<bool> CreateAsync(UserModel userModel, string nonHashedPassword)
        {
            var result = await _userManager.CreateAsync(userModel, nonHashedPassword);
            Console.WriteLine($"Created user succeeded: {result.Succeeded}");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userModel, Enums.Roles.User.ToString());
            }
            return result.Succeeded;
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
            await SetUserRole(item);
            return item;
        }

        public async Task<UserModel> GetUserById(string id)
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri($"{_baseUrl}/{id}"));
            UserModel user = JsonConvert.DeserializeObject<UserModel>(jsonContent);
            await SetUserRole(user);
            return user;
        }

        public async Task<UserModel> UpdateAsync(UserModel updatedModel)
        {
            string json = JsonConvert.SerializeObject(updatedModel);
            StringContent httpsContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(new Uri(_baseUrl), httpsContent);
            bool roleUpdateIsSuccess = await UpdateRoleAsync(updatedModel);
            if (response.IsSuccessStatusCode && roleUpdateIsSuccess)
            {
                return updatedModel;
            }
            return null;
        }
        public async Task<bool> UpdateRoleAsync(UserModel updatedModel)
        {
            string json = JsonConvert.SerializeObject(updatedModel);
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(new Uri($"{_baseUrl}/Role"), httpContent);

            return response.IsSuccessStatusCode;
        }
        private async Task SetUserRole(UserModel user)
        {
            try
            {
                IList<string> userRoles = await _userManager.GetRolesAsync(user);
                user.Role = userRoles.First();
            }
            catch
            {
                Console.WriteLine("Couldn't set User Role (SetUserRole in UserRepository)");
            }
        }

        public async Task<bool> DeleteUser(UserModel user)
        {
            var result = await _httpClient.DeleteAsync(new Uri(_baseUrl + "/" + user.Id));
            if (result.IsSuccessStatusCode)
            {
                return true;

            }
            return false;
        }
    }
}
