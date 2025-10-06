using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using CallCenterBackend.Data;      // Tu carpeta Data
using CallCenterBackend.Models;    // Tu carpeta Models

namespace CallCenterBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColaboradorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ColaboradorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/colaborador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colaborador>>> GetAll()
        {
            return await _context.Colaboradores.ToListAsync();
        }

        // GET: api/colaborador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colaborador>> GetById(int id)
        {
            var colaborador = await _context.Colaboradores.FindAsync(id);

            if (colaborador == null)
                return NotFound();

            return colaborador;
        }

        // POST: api/colaborador
        [HttpPost]
        public async Task<ActionResult<Colaborador>> Create(Colaborador colaborador)
        {
            _context.Colaboradores.Add(colaborador);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = colaborador.Id }, colaborador);
        }

        // PUT: api/colaborador/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Colaborador colaborador)
        {
            if (id != colaborador.Id)
                return BadRequest();

            _context.Entry(colaborador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColaboradorExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/colaborador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var colaborador = await _context.Colaboradores.FindAsync(id);
            if (colaborador == null)
                return NotFound();

            _context.Colaboradores.Remove(colaborador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColaboradorExists(int id)
        {
            return _context.Colaboradores.Any(e => e.Id == id);
        }
    }
}
