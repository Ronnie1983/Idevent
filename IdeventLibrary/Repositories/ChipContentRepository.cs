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
        private static string _baseUrl = $"{Helpers.ApiBaseUrl}/ChipContent/"; // TODO: change to online API
        private static HttpClient _httpClient = new HttpClient();
        public async Task<List<StandProductModel>> GetAllContentByStandIdAndChipIdAsync(int chipId, int standId)
        {
            string jsonContent = await _httpClient.GetStringAsync(new Uri(_baseUrl + chipId +"/"+ standId));
            List<StandProductModel> List = JsonConvert.DeserializeObject<List<StandProductModel>>(jsonContent);

            return List;
        }
    }
}
