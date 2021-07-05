using Biblioteca.WPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.WPF.API.Client
{
    public class BookRestService
    {
        private string baseUrl = "https://localhost:5001/api/Books";
        public async Task<List<BookModel>> GetBooks()
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}");

                var response = await client.SendAsync(request);

                var payload = JsonConvert.DeserializeObject<List<BookModel>>(await response.Content.ReadAsStringAsync());

                return payload;
            }

        }

        public async Task<BookModel> GetBookById(Guid bookId)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/{bookId}");

                var response = await client.SendAsync(request);

                var payload = JsonConvert.DeserializeObject<BookModel>(await response.Content.ReadAsStringAsync());

                return payload;
            }

        }

        public async Task<BookModel> CreateBook(BookModel book)
        {
            using (HttpClient clientHttp = new HttpClient())
            {
                var data = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

                var response = await clientHttp.PostAsync($"{baseUrl}", data);

                var payload = JsonConvert.DeserializeObject<BookModel>(await response.Content.ReadAsStringAsync());

                return payload;
            }
        }

        public async Task<BookModel> UpdateBook(Guid bookId, BookModel book)
        {
            using (HttpClient clientHttp = new HttpClient())
            {
                var data = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

                var response = await clientHttp.PutAsync($"{baseUrl}/{bookId}", data);

                var payload = JsonConvert.DeserializeObject<BookModel>(await response.Content.ReadAsStringAsync());

                return payload;
            }

        }

        public async Task DeleteBook(Guid bookId)
        {
            using (HttpClient clientHttp = new HttpClient())
            {
                var response = await clientHttp.DeleteAsync($"{baseUrl}/{bookId}");

            }
        }
    }
}
