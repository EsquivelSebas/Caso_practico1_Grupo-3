using casoPractico_1_Grup03.DBContext;
using casoPractico_1_Grup03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace casoPractico_1_Grup03.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        

        // reading the DB context
        private readonly AplicationDbContext _context;

        //controller creating diferent methods

        public UsuariosController(AplicationDbContext context)
        {
            //filling the local context with the DB context
            _context = context;
        }


        //get Users

        [HttpGet]
        public async Task<ActionResult<List<Usuarios>>> GetUsers()
        {
            return await _context.G3Usuario.ToListAsync();

        }


        //Get users by ID

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsersByID(int id)
        {
            var usuarios = await _context.G3Usuario.FindAsync(id);

            if (usuarios == null)
            {
                var mensajeError = new { mensaje = "User not found...... 😭" };
                return NotFound(mensajeError);
            }
            var mensaje = new { mensaje = "User Found.... 😊" };
            return Ok(new { user = usuarios, mensaje });
        }



        //post Users (ADD)
        [HttpPost]
        public async Task<ActionResult<Usuarios>> AddUsers([FromBody] Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                var mensajeError = new { msg = "Model is not loading properly.....😭" };
                return BadRequest(mensajeError);
            }

            var mensajeCorrecto = new { msg = "User added successfully" };
            _context.G3Usuario.Add(usuarios);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsersByID), new { id = usuarios.ID }, new { user = usuarios, mensajeCorrecto });

        }



        //Update Users (PUT)


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserById(int id, [FromBody] Usuarios usuarios)
        {
            // Validate that the ID in the route matches the ID in the request body
            if (id != usuarios.ID)
            {
                return BadRequest("The ID in the route does not match the ID in the request body.");
            }

            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the user exists in the database
            var existingUser = await _context.G3Usuario.FindAsync(id);
            if (existingUser == null)
            {
                return NotFound("The user does not exist.");
            }

            // Update the properties of the existing user
            _context.Entry(existingUser).CurrentValues.SetValues(usuarios);

            try
            {
                // Save the changes to the database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.G3Usuario.Any(u => u.ID == id))
                {
                    return NotFound("The user does not exist.");
                }
                else
                {
                    throw; // Throw the exception if it cannot be handled
                }
            }

            // Return a 204 (No Content) response
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuarios>> deleteUsersByID(int id)
        {
            //validation if exists
            var users = await _context.G3Usuario.FindAsync(id);
            if (users == null)
            {
                var mensajeError = new { msg = "User not Found.....😭" };
                return NotFound(mensajeError);
            }//but if it exists
            _context.G3Usuario.Remove(users);
            await _context.SaveChangesAsync();
            var mensajeCorrecto = new { msg = "User deleted successfully....😊" };
            return Ok(new { user = users, mensajeCorrecto });



        }
    }
}

