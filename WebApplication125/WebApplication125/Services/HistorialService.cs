using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.ResponseCompression;
using System.Text;
using System.Text.Json;
using WebApplication125.Models;

namespace WebApplication125.Services
{


    public class HistorialService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public HistorialService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration["ApiUrl"] + "Product/";
            //  "ApiUrl": "https://localhost:7233/api/Product/"
        }

        public async Task<List<HistorialModels>> GetHistorialesAsync()
        {
            var response = await _httpClient.GetAsync(_apiUrl);
            if (!response.IsSuccessStatusCode)
                return new List<HistorialModels>(); //aca viene como un objeto. 
            var json = await response.Content.ReadAsStringAsync();
            //Aca lo convertimos en un sring para JSON.

            return JsonSerializer.Deserialize<List<HistorialModels>>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            ) ?? new List<HistorialModels>();

        }

        public async Task<bool> AddHistorialesAsync(HistorialModels historiales)
        {
            var jsonHistoriales = JsonSerializer.Serialize(historiales);
            var content = new StringContent(jsonHistoriales, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_apiUrl, content);

            return response.IsSuccessStatusCode;

        }

        public async Task<bool> UpdateHistorialesAsync(HistorialModels historiales)
        {
            var jsonHistoriales = JsonSerializer.Serialize(historiales);
            var content = new StringContent(jsonHistoriales, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_apiUrl}{historiales.Id}", content);

            return response.IsSuccessStatusCode;

        }

        public async Task<bool> DeleteHistorialesAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiUrl}{id}");

            return response.IsSuccessStatusCode;

        }

    }
}