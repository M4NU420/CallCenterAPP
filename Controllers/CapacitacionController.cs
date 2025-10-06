using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CallCenterBackend.Data;
using CallCenterBackend.Models;

namespace CallCenterBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CapacitacionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CapacitacionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Capacitacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Capacitacion>>> GetAll()
        {
            return await _context.Capacitaciones
                .Include(c => c.Sesiones)
                .Include(c => c.Participaciones)
                .Include(c => c.Evaluaciones)
                .Include(c => c.CapacitadoresAsignados)
                .ToListAsync();
        }

        // GET: api/Capacitacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Capacitacion>> GetById(int id)
        {
            var capacitacion = await _context.Capacitaciones
                .Include(c => c.Sesiones)
                .Include(c => c.Participaciones)
                .Include(c => c.Evaluaciones)
                .Include(c => c.CapacitadoresAsignados)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (capacitacion == null)
                return NotFound();

            return capacitacion;
        }

        // POST: api/Capacitacion
        [HttpPost]
        public async Task<ActionResult<Capacitacion>> Create(Capacitacion capacitacion)
        {
            _context.Capacitaciones.Add(capacitacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = capacitacion.Id }, capacitacion);
        }

        // PUT: api/Capacitacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Capacitacion capacitacion)
        {
            if (id != capacitacion.Id)
                return BadRequest();

            _context.Entry(capacitacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Capacitacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var capacitacion = await _context.Capacitaciones.FindAsync(id);
            if (capacitacion == null)
                return NotFound();

            _context.Capacitaciones.Remove(capacitacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
