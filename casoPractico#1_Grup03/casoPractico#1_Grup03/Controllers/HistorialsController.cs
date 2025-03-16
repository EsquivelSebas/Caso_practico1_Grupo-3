using Microsoft.AspNetCore.Mvc;
using casoPractico_1_Grup03.Models;

using casoPractico_1_Grup03.DBContext;
using Microsoft.EntityFrameworkCore;


namespace casoPractico_1_Grup03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialsController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public HistorialsController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Historials
        [HttpGet]
        public async Task<ActionResult<List<Historial>>> GetHistorials()
        {
            return await _context.G3Historial.ToListAsync();
        }

        // GET: api/Historials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Historial>> GetHistorialById(int id)
        {
            var historial = await _context.G3Historial.FindAsync(id);

            if (historial == null)
            {
                return NotFound();
            }

            return historial;
        }

        // POST: api/Historials
        [HttpPost]
        public async Task<ActionResult<Historial>> AddHistorial([FromBody] Historial historial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.G3Historial.Add(historial);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHistorialById), new { id = historial.Id }, historial);
        }

        // PUT: api/Historials/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHistorial(int id, [FromBody] Historial historial)
        {
            if (id != historial.Id)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingHistorial = await _context.G3Historial.FindAsync(id);
            if (existingHistorial == null)
            {
                return NotFound();
            }

            _context.Entry(existingHistorial).CurrentValues.SetValues(historial);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.G3Historial.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Historials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorial(int id)
        {
            var historial = await _context.G3Historial.FindAsync(id);
            if (historial == null)
            {
                return NotFound();
            }

            _context.G3Historial.Remove(historial);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
