using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pride_;
using Pride_.Domain;

namespace Pride_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientsController : ControllerBase
    {
        private readonly PrideMoreContext _context;

        public PacientsController(PrideMoreContext context)
        {
            _context = context;
        }

        // GET: api/Pacients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pacient>>> Getpacients()
        {
            return await _context.pacients.ToListAsync();
        }

        // GET: api/Pacients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pacient>> GetPacient(string id)
        {
            var pacient = await _context.pacients.FindAsync(id);

            if (pacient == null)
            {
                return NotFound();
            }

            return pacient;
        }

        // PUT: api/Pacients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPacient(string id, Pacient pacient)
        {
            if (id != pacient.CPF)
            {
                return BadRequest();
            }

            _context.Entry(pacient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacientExists(id))
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

        // POST: api/Pacients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pacient>> PostPacient(Pacient pacient)
        {
            _context.pacients.Add(pacient);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PacientExists(pacient.CPF))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPacient", new { id = pacient.CPF }, pacient);
        }

        // DELETE: api/Pacients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pacient>> DeletePacient(string id)
        {
            var pacient = await _context.pacients.FindAsync(id);
            if (pacient == null)
            {
                return NotFound();
            }

            _context.pacients.Remove(pacient);
            await _context.SaveChangesAsync();

            return pacient;
        }

        private bool PacientExists(string id)
        {
            return _context.pacients.Any(e => e.CPF == id);
        }
    }
}
