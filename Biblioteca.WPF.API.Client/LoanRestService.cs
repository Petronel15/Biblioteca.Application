using Biblioteca.WPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.WPF.API.Client
{
    public class LoanRestService
    {
        private string baseUrl = "https://localhost:5001/api/Loans";

        public async Task<List<LoanModel>> GetLoans()
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}");

                var response = await client.SendAsync(request);

                var payload = JsonConvert.DeserializeObject<List<LoanModel>>(await response.Content.ReadAsStringAsync());

                return payload;
            }

        }

        public async Task<LoanModel> GetLoanById(Guid loanId)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/{loanId}");

                var response = await client.SendAsync(request);

                var payload = JsonConvert.DeserializeObject<LoanModel>(await response.Content.ReadAsStringAsync());

                return payload;
            }

        }

        public async Task<LoanModel> CreateLoan(LoanModel loan)
        {
            using (HttpClient clientHttp = new HttpClient())
            {
                var data = new StringContent(JsonConvert.SerializeObject(loan), Encoding.UTF8, "application/json");

                var response = await clientHttp.PostAsync($"{baseUrl}", data);

                var payload = JsonConvert.DeserializeObject<LoanModel>(await response.Content.ReadAsStringAsync());

                return payload;
            }
        }

        public async Task<LoanModel> UpdateLoan(Guid loanId, LoanModel loan)
        {
            using (HttpClient clientHttp = new HttpClient())
            {
                var data = new StringContent(JsonConvert.SerializeObject(loan), Encoding.UTF8, "application/json");

                var response = await clientHttp.PutAsync($"{baseUrl}/{loanId}", data);

                var payload = JsonConvert.DeserializeObject<LoanModel>(await response.Content.ReadAsStringAsync());

                return payload;
            }

        }

        public async Task DeleteLoan(Guid loanId)
        {
            using (HttpClient clientHttp = new HttpClient())
            {
                var response = await clientHttp.DeleteAsync($"{baseUrl}/{loanId}");

            }
        }
    }
}
