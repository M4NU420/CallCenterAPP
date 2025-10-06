using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CallCenterBackend.Data;
using CallCenterBackend.Models;

namespace CallCenterBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluacionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EvaluacionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Evaluacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evaluacion>>> GetAll()
        {
            return await _context.Evaluaciones
                .Include(e => e.Colaborador)
                .Include(e => e.Capacitacion)
                .ToListAsync();
        }

        // GET: api/Evaluacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evaluacion>> GetById(int id)
        {
            var evaluacion = await _context.Evaluaciones
                .Include(e => e.Colaborador)
                .Include(e => e.Capacitacion)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (evaluacion == null)
                return NotFound();

            return evaluacion;
        }

        // POST: api/Evaluacion
        [HttpPost]
        public async Task<ActionResult<Evaluacion>> Create(Evaluacion evaluacion)
        {
            _context.Evaluaciones.Add(evaluacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = evaluacion.Id }, evaluacion);
        }

        // PUT: api/Evaluacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Evaluacion evaluacion)
        {
            if (id != evaluacion.Id)
                return BadRequest();

            _context.Entry(evaluacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Evaluacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var evaluacion = await _context.Evaluaciones.FindAsync(id);
            if (evaluacion == null)
                return NotFound();

            _context.Evaluaciones.Remove(evaluacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
