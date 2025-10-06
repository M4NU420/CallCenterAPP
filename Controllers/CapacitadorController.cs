using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CallCenterBackend.Data;
using CallCenterBackend.Models;

namespace CallCenterBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CapacitadorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CapacitadorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Capacitador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Capacitador>>> GetAll()
        {
            return await _context.Capacitadores
                .Include(c => c.CapacitacionesAsignadas)
                .ToListAsync();
        }

        // GET: api/Capacitador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Capacitador>> GetById(int id)
        {
            var capacitador = await _context.Capacitadores
                .Include(c => c.CapacitacionesAsignadas)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (capacitador == null)
                return NotFound();

            return capacitador;
        }

        // POST: api/Capacitador
        [HttpPost]
        public async Task<ActionResult<Capacitador>> Create(Capacitador capacitador)
        {
            _context.Capacitadores.Add(capacitador);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = capacitador.Id }, capacitador);
        }

        // PUT: api/Capacitador/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Capacitador capacitador)
        {
            if (id != capacitador.Id)
                return BadRequest();

            _context.Entry(capacitador).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Capacitador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var capacitador = await _context.Capacitadores.FindAsync(id);
            if (capacitador == null)
                return NotFound();

            _context.Capacitadores.Remove(capacitador);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
