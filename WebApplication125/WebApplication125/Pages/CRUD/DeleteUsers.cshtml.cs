using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication125.Models;
using WebApplication125.Services;

namespace WebApplication125.Pages.CRUD
{
    public class DeleteUsersModel : PageModel
    {
        private readonly UsuarioService _usuarioService;


        public DeleteUsersModel(UsuarioService usuarioService)

        {
            _usuarioService = usuarioService;

        }


        [BindProperty]
        public UsuarioModels _UsuarioModels { get; set; } = new();


       public async Task<IActionResult> OnGetAsync(int id)
        {
            var productos = await _usuarioService.GetUsuariosAsync();
            _UsuarioModels = productos.FirstOrDefault(p => p.Id == id);

            if (_UsuarioModels == null)
            {
                return NotFound();
            }
            return Page();
            var response = await _usuarioService.DeleteUsuariosAsync(_UsuarioModels.Id);

        }




        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _usuarioService.DeleteUsuariosAsync(_UsuarioModels.Id);
            if (response)
            {
                return RedirectToPage("Usuario");
            }
            else
            {
                return Page();
            }
        }
        




    }
}
