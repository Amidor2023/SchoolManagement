using Gestion_Emploi.Data;
using Gestion_Emploi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Emploi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassmatesController : ControllerBase
    {
        private readonly Gestion_EmploiContext _context;

        public ClassmatesController(Gestion_EmploiContext context) => _context = context;

        // GET: api/Classmates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classmate>>> GetClassmate()
        {
            return await _context.Classmate.ToListAsync();
        }

        // GET: api/Classmates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Classmate>> GetClassmate(Guid id)
        {
            Classmate? classmate = await _context.Classmate.FindAsync(id);

            if (classmate == null)
            {
                return NotFound();
            }

            return classmate;
        }

        // PUT: api/Classmates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassmate(Guid id, Classmate classmate)
        {
            if (id != classmate.Id)
            {
                return BadRequest();
            }

            _context.Entry(classmate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassmateExists(id))
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

        // POST: api/Classmates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Classmate>> PostClassmate(Classmate classmate)
        {
            _context.Classmate.Add(classmate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassmate", new { id = classmate.Id }, classmate);
        }

        // DELETE: api/Classmates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassmate(Guid id)
        {
            Classmate? classmate = await _context.Classmate.FindAsync(id);
            if (classmate == null)
            {
                return NotFound();
            }

            _context.Classmate.Remove(classmate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassmateExists(Guid id)
        {
            return _context.Classmate.Any(e => e.Id == id);
        }
    }
}
