using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;
using WebApplication125.Models;
using WebApplication125.Services;

namespace WebApplication125.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UsuarioService _usuarioService;
        

        public IndexModel(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public List<UsuarioModels> _UsuarioModels { get; set; } = new();

        public async Task OnGetAsync()
        {
            _UsuarioModels = await _usuarioService.GetUsuariosAsync();
        }

    }
}
