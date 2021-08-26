using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KomgrichApi.Models;

namespace KomgrichApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class universitiesController : ControllerBase
    {
        private readonly universitiesContext _context;

        public universitiesController(universitiesContext context)
        {
            _context = context;
        }

        // GET: api/universities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<universities>>> Getuniversitie()
        {
            return await _context.universitie.ToListAsync();
        }

        // GET: api/universities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<universities>> Getuniversities(long id)
        {
            var universities = await _context.universitie.FindAsync(id);

            if (universities == null)
            {
                return NotFound();
            }

            return universities;
        }

        // PUT: api/universities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putuniversities(long id, universities universities)
        {
            if (id != universities.Id)
            {
                return BadRequest();
            }

            _context.Entry(universities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!universitiesExists(id))
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

        // POST: api/universities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<universities>> Postuniversities(universities universities)
        {
            _context.universitie.Add(universities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getuniversities", new { id = universities.Id }, universities);
        }

        // DELETE: api/universities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteuniversities(long id)
        {
            var universities = await _context.universitie.FindAsync(id);
            if (universities == null)
            {
                return NotFound();
            }

            _context.universitie.Remove(universities);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool universitiesExists(long id)
        {
            return _context.universitie.Any(e => e.Id == id);
        }
    }
}
