using Gestion_Emploi.Data;
using Gestion_Emploi.Dtos;
using Gestion_Emploi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Emploi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly Gestion_EmploiContext _context;

        public TeachersController(Gestion_EmploiContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Teacher> teachers =  await _context.Teacher.ToListAsync();

            List<TeacherOutput> teacherOutputs = new();

            foreach (Teacher teacher in teachers)
            {
                TeacherOutput teacherOutput = new()
                {
                    Id = teacher.Id,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    Email = teacher.Email,
                    Reference = teacher.Reference,
                    Experience = teacher.Experience,
                };

                teacherOutputs.Add(teacherOutput);
            }

            return Ok(teacherOutputs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            Teacher? teacher = await _context.Teacher
                .SingleOrDefaultAsync(t => t.Id == id);

            if (teacher == null)
            {
                return NotFound();
            }
            else
            {
                TeacherOutput teacherOutput = new()
                {
                    Id = teacher.Id,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    Email = teacher.Email,
                    Reference = teacher.Reference,
                    Experience = teacher.Experience,
                };

                return Ok(teacherOutput);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, TeacherInput teacherInput)
        {
            Teacher? teacher = await _context.Teacher
                .SingleOrDefaultAsync(c => c.Id == id);

            if (teacher == null)
            {
                return NotFound();
            }
            else
            {
                teacher.Id = id;
                teacher.UpdatedAt = DateTime.Now;
                teacher.FirstName = teacherInput.FirstName;
                teacher.LastName = teacherInput.LastName;
                teacher.Email = teacherInput.Email;
                teacher.Password = teacherInput.Password;

                _context.Entry(teacher).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return Ok("Updated");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Teacher>> Post(TeacherInput teacherInput)
        {
            Random rnd = new ();

            int randomInt = rnd.Next(1000, 10000);

            Teacher teacher = new()
            {
                FirstName = teacherInput.FirstName,
                LastName = teacherInput.LastName,
                Email = teacherInput.LastName,
                Password = teacherInput.Password,
                Reference = "TE" + randomInt.ToString(),
                CreatedAt = DateTime.Now,
                Experience = teacherInput.Experience,
                
            };

            _context.Teacher.Add(teacher);

            await _context.SaveChangesAsync();

            return Ok(teacher);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Teacher? teacher = await _context.Teacher
                .SingleOrDefaultAsync(t => t.Id == id);

            if (teacher == null)
            {
                return NotFound();
            }
            else
            {
                _context.Teacher.Remove(teacher);
                
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }

        private bool TeacherExists(Guid id)
        {
            return _context.Teacher.Any(e => e.Id == id);
        }
    }
}
