using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CallCenterBackend.Data;
using CallCenterBackend.Models;

namespace CallCenterBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SesionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SesionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sesion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sesion>>> GetAll()
        {
            return await _context.Sesiones
                .Include(s => s.Capacitacion)
                .ToListAsync();
        }

        // GET: api/Sesion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sesion>> GetById(int id)
        {
            var sesion = await _context.Sesiones
                .Include(s => s.Capacitacion)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sesion == null)
                return NotFound();

            return sesion;
        }

        // POST: api/Sesion
        [HttpPost]
        public async Task<ActionResult<Sesion>> Create(Sesion sesion)
        {
            _context.Sesiones.Add(sesion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = sesion.Id }, sesion);
        }

        // PUT: api/Sesion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Sesion sesion)
        {
            if (id != sesion.Id)
                return BadRequest();

            _context.Entry(sesion).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Sesion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sesion = await _context.Sesiones.FindAsync(id);
            if (sesion == null)
                return NotFound();

            _context.Sesiones.Remove(sesion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
