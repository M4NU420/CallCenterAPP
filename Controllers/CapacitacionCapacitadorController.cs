using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CallCenterBackend.Data;
using CallCenterBackend.Models;

namespace CallCenterBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CapacitacionCapacitadorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CapacitacionCapacitadorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CapacitacionCapacitador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CapacitacionCapacitador>>> GetAll()
        {
            return await _context.CapacitacionCapacitadores
                .Include(x => x.Capacitacion)
                .Include(x => x.Capacitador)
                .ToListAsync();
        }

        // GET: api/CapacitacionCapacitador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CapacitacionCapacitador>> GetById(int id)
        {
            var item = await _context.CapacitacionCapacitadores
                .Include(x => x.Capacitacion)
                .Include(x => x.Capacitador)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/CapacitacionCapacitador
        [HttpPost]
        public async Task<ActionResult<CapacitacionCapacitador>> Create(CapacitacionCapacitador registro)
        {
            _context.CapacitacionCapacitadores.Add(registro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = registro.Id }, registro);
        }

        // PUT: api/CapacitacionCapacitador/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CapacitacionCapacitador registro)
        {
            if (id != registro.Id)
                return BadRequest();

            _context.Entry(registro).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/CapacitacionCapacitador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var registro = await _context.CapacitacionCapacitadores.FindAsync(id);
            if (registro == null)
                return NotFound();

            _context.CapacitacionCapacitadores.Remove(registro);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
