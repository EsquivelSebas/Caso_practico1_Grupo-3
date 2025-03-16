using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication125.Models;
using WebApplication125.Services;

namespace WebApplication125.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UsuarioService _usuarioService;


        public LoginModel(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [BindProperty]

        public UsuarioModels _UsuarioModel { get; set; } = new();

        public string Mensaje { get; set; } = string.Empty;

        public async Task<IActionResult> OnPostAsync(string nombre, string contraseña)
        {
            var usuarios = await _usuarioService.GetUsuariosAsync();
            _UsuarioModel = usuarios.FirstOrDefault(u => u.Nombre_Usuario == nombre && u.Contraseña == contraseña);
            if(_UsuarioModel == null)
            {
                return NotFound();
            }
            return RedirectToPage("Index");

        }
           
    }
}



