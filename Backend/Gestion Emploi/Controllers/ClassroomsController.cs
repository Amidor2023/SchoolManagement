using Gestion_Emploi.Data;
using Gestion_Emploi.Dtos;
using Gestion_Emploi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Emploi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private readonly Gestion_EmploiContext _context;

        public ClassroomsController(Gestion_EmploiContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Classroom> classrooms =  await _context.Classroom.ToListAsync();

            List<ClassroomOutput> classroomOutputDtos = new ();

            foreach (Classroom classroom in classrooms)
            {
                ClassroomOutput classroomOutputDto = new()
                {
                    Id = classroom.Id,
                    Floor = classroom.Floor,
                    Free = classroom.Free,
                    Number = classroom.Number
                };

                classroomOutputDtos.Add(classroomOutputDto);
            }

            return Ok(classroomOutputDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            Classroom? classroom = await _context.Classroom
                .SingleOrDefaultAsync(c => c.Id == id);

            if (classroom == null)
            {
                return NotFound();
            }

            ClassroomOutput classroomOutputDto = new()
            {
                Id = classroom.Id,
                Floor = classroom.Floor,
                Free = classroom.Free,
                Number = classroom.Number
            };

            return Ok(classroomOutputDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, ClassroomInput classroomInput)
        {
            Classroom? classroom = await _context.Classroom
                .SingleOrDefaultAsync(c => c.Id == id);
            
            if(classroom == null)
            {
                return NotFound();
            }
            else
            {
                classroom.Id = id;
                classroom.UpdatedAt = DateTime.Now;
                classroom.Floor = classroomInput.Floor;
                classroom.Free = classroom.Free;
                classroom.Number = classroomInput.Number;

                _context.Entry(classroom).State = EntityState.Modified;
                
                await _context.SaveChangesAsync();
                
                return Ok("Updated");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClassroomInput classroomInput)
        {
            Classroom classroom = new()
            {
                Number = classroomInput.Number,
                Floor = classroomInput.Floor,
                Free = true,
                CreatedAt = DateTime.Now,
            };

            _context.Classroom.Add(classroom);
            await _context.SaveChangesAsync();

            ClassroomOutput classroomOutput = new()
            {
                Id = classroom.Id,
                Floor = classroom.Floor,
                Number = classroom.Number,
                Free = classroom.Free
            };

            return Ok(classroomOutput);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Classroom? classroom = await _context.Classroom
                .SingleOrDefaultAsync(c => c.Id == id);

            if (classroom == null)
            {
                return NotFound();
            }
            else
            {
                _context.Classroom.Remove(classroom);

                await _context.SaveChangesAsync();

                return NoContent();
            }
        }
    }
}
