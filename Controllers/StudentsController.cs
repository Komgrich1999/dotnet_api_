using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KomgrichApi.Models;
using Dapper;
using Newtonsoft.Json;

namespace KomgrichApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsContext _context;
        
        public StudentsController(StudentsContext context)
        {
            _context = context;
            
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudent()
        {
            return await _context.Student.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Students>> GetStudents(long id)
        {
            //var students = await _context.Student.FindAsync(id);
            
            string _id = id.ToString();
            Console.WriteLine(_id.GetType());
            var query = @"select uni.""Id"", st.student_id , st.fullname , st.""degree"" , uni.university_name , st.""universities_id"" from ""Student"" as st" 
                       +" join universitie as uni "
                       +"on uni.\"Id\" = st.universities_id"
                       +$" where student_id = '{_id}' offset 0";
            /*
            var students =  await _context.Student.FromSqlRaw(query)
                            .OrderByDescending(st => st.Id)
                            .Include("universitie")
                            .ToListAsync()
                            ;*/

            var students = await _context.Student.FromSqlRaw(query)
                                                 .Include("universitie")
                                                 .ToListAsync();
            
            
            if (students == null)
            {
                return NotFound();
            }
            
            return Ok(students) ;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudents(long id, Students students)
        {
            if (id != students.Id)
            {
                return BadRequest();
            }

            _context.Entry(students).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(id))
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

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Students>> PostStudents(Students students)
        {
            _context.Student.Add(students);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudents", new { id = students.Id }, students);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudents(long id)
        {
            var students = await _context.Student.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }

            _context.Student.Remove(students);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentsExists(long id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
