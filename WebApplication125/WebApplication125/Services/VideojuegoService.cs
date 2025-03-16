using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.ResponseCompression;
using System.Text;
using System.Text.Json;
using WebApplication125.Models;

namespace WebApplication125.Services
{


    public class VideojuegoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public VideojuegoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration["ApiUrl"] + "Product/";
            //  "ApiUrl": "https://localhost:7258/api/Product/"
        }

        public async Task<List<VideojuegoModels>> GetVideojuegosAsync()
        {
            var response = await _httpClient.GetAsync(_apiUrl);
            if (!response.IsSuccessStatusCode)
                return new List<VideojuegoModels>(); //aca viene como un objeto. 
            var json = await response.Content.ReadAsStringAsync();
            //Aca lo convertimos en un sring para JSON.

            return JsonSerializer.Deserialize<List<VideojuegoModels>>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            ) ?? new List<VideojuegoModels>();

        }

        public async Task<bool> AddVideojuegosAsync(VideojuegoModels videojuegos)
        {
            var jsonVideojuegos = JsonSerializer.Serialize(videojuegos);
            var content = new StringContent(jsonVideojuegos, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_apiUrl, content);

            return response.IsSuccessStatusCode;

        }

        public async Task<bool> UpdateVideojuegosAsync(VideojuegoModels videojuegos)
        {
            var jsonVideojuegos = JsonSerializer.Serialize(videojuegos);
            var content = new StringContent(jsonVideojuegos, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_apiUrl}{videojuegos.Id}", content);

            return response.IsSuccessStatusCode;

        }

        public async Task<bool> DeleteVideojuegosAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiUrl}{id}");

            return response.IsSuccessStatusCode;

        }
    }
}
