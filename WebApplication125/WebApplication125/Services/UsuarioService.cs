using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.ResponseCompression;
using System.Text;
using System.Text.Json;
using WebApplication125.Models;

namespace WebApplication125.Services
{


    public class UsuarioService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public UsuarioService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration["ApiUrl"] + "Usuarios/";
            //  "ApiUrl": "https://localhost:7258/api/Usuarios/"
        }

        public async Task<List<UsuarioModels>> GetUsuariosAsync()
        {
            var response = await _httpClient.GetAsync(_apiUrl);
            if (!response.IsSuccessStatusCode)
                return new List<UsuarioModels>(); //aca viene como un objeto. 
            var json = await response.Content.ReadAsStringAsync();
            //Aca lo convertimos en un sring para JSON.

            return JsonSerializer.Deserialize<List<UsuarioModels>>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            ) ?? new List<UsuarioModels>();

        }


        public async Task<bool> AddUsuariosAsync(UsuarioModels usuarios)
        {
            var jsonUsuarios = JsonSerializer.Serialize(usuarios);
            var content = new StringContent(jsonUsuarios, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_apiUrl, content);

            return response.IsSuccessStatusCode;
        
        }

        public async Task<bool> UpdateUsuariosAsync(UsuarioModels usuarios)
        {
            var jsonUsuarios = JsonSerializer.Serialize(usuarios);
            var content = new StringContent(jsonUsuarios, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_apiUrl}{usuarios.Id}", content);

            return response.IsSuccessStatusCode;
        
        }

        public async Task<bool> DeleteUsuariosAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiUrl}{id}");
            
            return response.IsSuccessStatusCode;
        
        }
    
    }
}



