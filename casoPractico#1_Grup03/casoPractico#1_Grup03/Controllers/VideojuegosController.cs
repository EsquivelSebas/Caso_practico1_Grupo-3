using casoPractico_1_Grup03.DBContext;
using casoPractico_1_Grup03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace casoPractico_1_Grup03.Controllers
{
    [Route("api/[controller]")]
    public class VideojuegosController : Controller
    {
        private readonly AplicationDbContext _context;

        public VideojuegosController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Videojuego>>> GetVideojuegos()
        {
            return await _context.G3Videojuego.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Videojuego>> GetVideojuegoByID(int id)
        {
            var videojuego = await _context.G3Videojuego.FindAsync(id);

            if (videojuego == null)
            {
                var mensajeError = new { mensaje = "Videojuego not found...... 😭" };
                return NotFound(mensajeError);
            }
            var mensaje = new { mensaje = "Videojuego Found.... 😊" };
            return Ok(new { videojuego, mensaje });
        }

        [HttpPost]
        public async Task<ActionResult<Videojuego>> AddVideojuego([FromBody] Videojuego videojuego)
        {
            if (!ModelState.IsValid)
            {
                var mensajeError = new { msg = "Model is not loading properly.....😭" };
                return BadRequest(mensajeError);
            }

            var mensajeCorrecto = new { msg = "Videojuego added successfully" };
            _context.G3Videojuego.Add(videojuego);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVideojuegoByID), new { id = videojuego.Id }, new { videojuego, mensajeCorrecto });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVideojuegoById(int id, [FromBody] Videojuego videojuego)
        {
            if (id != videojuego.Id)
            {
                return BadRequest("The ID in the route does not match the ID in the request body.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingVideojuego = await _context.G3Videojuego.FindAsync(id);
            if (existingVideojuego == null)
            {
                return NotFound("The videojuego does not exist.");
            }

            _context.Entry(existingVideojuego).CurrentValues.SetValues(videojuego);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.G3Videojuego.Any(v => v.Id == id))
                {
                    return NotFound("The videojuego does not exist.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Videojuego>> DeleteVideojuegoByID(int id)
        {
            var videojuego = await _context.G3Videojuego.FindAsync(id);
            if (videojuego == null)
            {
                var mensajeError = new { msg = "Videojuego not Found.....😭" };
                return NotFound(mensajeError);
            }
            _context.G3Videojuego.Remove(videojuego);
            await _context.SaveChangesAsync();
            var mensajeCorrecto = new { msg = "Videojuego deleted successfully....😊" };
            return Ok(new { videojuego, mensajeCorrecto });
        }
    }
    }
