using Biblioteca.WPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.WPF.API.Client
{
    public class CustomerRestService
    {
        private string baseUrl = "https://localhost:5001/api/Customers";

        public async Task<List<ClientModel>> GetClients()
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}");

                var response = await client.SendAsync(request);

                var payload = JsonConvert.DeserializeObject<List<ClientModel>>(await response.Content.ReadAsStringAsync());

                return payload;
            }

        }

        public async Task<ClientModel> GetClientById(Guid id)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/{id}");

                var response = await client.SendAsync(request);

                var payload = JsonConvert.DeserializeObject<ClientModel>(await response.Content.ReadAsStringAsync());

                return payload;
            }

        }

        public async Task<ClientModel> CreateClient(ClientModel client)
        {
            using (HttpClient clientHttp = new HttpClient())
            {
                var data = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json");

                var response = await clientHttp.PostAsync($"{baseUrl}", data);

                var payload = JsonConvert.DeserializeObject<ClientModel>(await response.Content.ReadAsStringAsync());

                return payload;
            }
        }

        public async Task<ClientModel> UpdateClient(Guid clientId, ClientModel client)
        {
            using (HttpClient clientHttp = new HttpClient())
            {
                var data = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json");

                var response = await clientHttp.PutAsync($"{baseUrl}/{clientId}", data);

                var payload = JsonConvert.DeserializeObject<ClientModel>(await response.Content.ReadAsStringAsync());

                return payload;
            }

        }

        public async Task DeleteClient(Guid clientId)
        {
            using (HttpClient clientHttp = new HttpClient())
            {
                var response = await clientHttp.DeleteAsync($"{baseUrl}/{clientId}");

            }
        }
    }
}
