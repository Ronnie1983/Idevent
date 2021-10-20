using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using IdeKortLib.Models;

namespace ConsoleApp1.Database
{
    public class ConnectionGeneric<T> : MethodDB
    {
        public async Task<T> GetItemById(int id)
        {
            using HttpClient client = new()
            {
                BaseAddress = new Uri($"{URL}{typeof(T).Name}s/")
            };

            T content = await client.GetFromJsonAsync<T>($"{id}");
            return content;
        }
        public async Task<List<T>> GetItemByCip(int id)
        {
            using HttpClient client = new()
            {
                BaseAddress = new Uri($"{URL}{typeof(T).Name}s/chip/")
            };

            List<T> content = await client.GetFromJsonAsync<List<T>>($"{id}");
            return content;
        }

        public async Task<T> UpdatItem(int id,T item)
        {
            using HttpClient client = new()
            {
                BaseAddress = new Uri($"{URL}/")
            };
            HttpResponseMessage response = await client.PutAsJsonAsync($"{typeof(T).Name}s/{id}",item);
            T result = await GetItemById(id);
            return result;
        }

        public async Task<T> DecreaseByAmount(int id, int amount)
        {
            using HttpClient client = new()
            {
                BaseAddress = new Uri($"{URL}{typeof(T).Name}s/Decrease/")
            };

            T content = await client.GetFromJsonAsync<T>($"{id}/{amount}");
            return content;
        }
    }
}
