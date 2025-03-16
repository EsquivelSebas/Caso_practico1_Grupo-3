using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using WebApplication125.Models;
using WebApplication125.Services;

namespace WebApplication125.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UsuarioService _usuarioService;
        

        public RegisterModel(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [BindProperty]

        public UsuarioModels _UsuarioModel { get; set; } = new();

        public string Mensaje { get; set; } = string.Empty;

        public async Task<IActionResult> OnPostAsync()
        {
            try 
            {
                if (!ModelState.IsValid)
                {
                    Mensaje = "Datos invalidos";
                    return Page();
                }

                var response = await _usuarioService.AddUsuariosAsync(_UsuarioModel);

                if (response)
                {
                    Mensaje = "Usuario registrado";
                    return RedirectToPage("Register");
                }
                else
                {
                    Mensaje = "Error al registrar un usuario";
                    return RedirectToPage("Register");

                }
            }
            catch (Exception ex)
            {
                Mensaje = "Error " + ex.Message;
                return Page();
            }

            
        }

    }
}