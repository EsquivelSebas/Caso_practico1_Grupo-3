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
        public UsuarioModels Usuario { get; set; } = new();

        public string Mensaje { get; set; } = string.Empty;

        public void OnGet()
        {
            // Inicializa cualquier dato necesario para la vista (opcional).
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Usuario.Nombre_Usuario) || string.IsNullOrWhiteSpace(Usuario.Contraseña))
            {
                Mensaje = "El nombre de usuario y la contraseña son obligatorios.";
                return Page();
            }

            var usuarios = await _usuarioService.GetUsuariosAsync();
            var usuarioValido = usuarios.FirstOrDefault(u =>
                u.Nombre_Usuario == Usuario.Nombre_Usuario &&
                u.Contraseña == Usuario.Contraseña);

            if (usuarioValido == null)
            {
                Mensaje = "Credenciales incorrectas. Por favor, inténtalo de nuevo.";
                return Page();
            }

            
            return RedirectToPage("Register");
        }
    }
}



