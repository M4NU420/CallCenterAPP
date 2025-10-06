using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CallCenterBackend.Data;
using CallCenterBackend.Models;

namespace CallCenterBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipacionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ParticipacionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Participacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participacion>>> GetAll()
        {
            return await _context.Participaciones
                .Include(p => p.Colaborador)
                .Include(p => p.Capacitacion)
                .ToListAsync();
        }

        // GET: api/Participacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participacion>> GetById(int id)
        {
            var participacion = await _context.Participaciones
                .Include(p => p.Colaborador)
                .Include(p => p.Capacitacion)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (participacion == null)
                return NotFound();

            return participacion;
        }

        // POST: api/Participacion
        [HttpPost]
        public async Task<ActionResult<Participacion>> Create(Participacion participacion)
        {
            _context.Participaciones.Add(participacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = participacion.Id }, participacion);
        }

        // PUT: api/Participacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Participacion participacion)
        {
            if (id != participacion.Id)
                return BadRequest();

            _context.Entry(participacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Participacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var participacion = await _context.Participaciones.FindAsync(id);
            if (participacion == null)
                return NotFound();

            _context.Participaciones.Remove(participacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
