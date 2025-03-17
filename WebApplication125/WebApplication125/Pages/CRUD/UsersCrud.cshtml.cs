using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication125.Models;
using WebApplication125.Services;

namespace WebApplication125.Pages.CRUD
{
    public class UsersCrudModel : PageModel
    {
        private readonly UsuarioService _usuarioService;


        public UsersCrudModel(UsuarioService usuarioService)

        {
            _usuarioService = usuarioService;

        }





        [BindProperty]
        public UsuarioModels _UsuarioModels { get; set; } = new();


        public string Mensaje { get; set; } = string.Empty;
        //post 
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
           {
               Mensaje = "Datos Invalidos";
                return Page();
            }

           try
            {
                //var jsonUsuarios = JsonSerializer.Serialize(_UsuarioModels);
                //var content = new StringContent(jsonUsuarios, Encoding.UTF8, "application/json");
                var response = await _usuarioService.AddUsuariosAsync(_UsuarioModels);
                if (response)
                {
                    Mensaje = "Producto Agregado";
                   return RedirectToPage("Usuario");
                }
                else
               {
                    Mensaje = "Ocurrio un error al agregar el producto";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                Mensaje = $"Ocurrio un error: {ex.Message}";
                return Page();
            }
        }

        

    }
}
