using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleDbConnection.Model;

namespace SampleDbConnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDetailsController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public StudentDetailsController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDetails>>> GetStudentDetailsTraining()
        {
            return await _context.StudentDetailsTraining.ToListAsync();
        }

        // GET: api/StudentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDetails>> GetStudentDetails(int id)
        {
            var studentDetails = await _context.StudentDetailsTraining.FindAsync(id);

            if (studentDetails == null)
            {
                return NotFound();
            }

            return studentDetails;
        }

        // PUT: api/StudentDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentDetails(int id, StudentDetails studentDetails)
        {
            if (id != studentDetails.id)
            {
                return BadRequest();
            }

            _context.Entry(studentDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentDetailsExists(id))
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

        // POST: api/StudentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentDetails>> PostStudentDetails(StudentDetails studentDetails)
        {
            _context.StudentDetailsTraining.Add(studentDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentDetails", new { id = studentDetails.id }, studentDetails);
        }

        // DELETE: api/StudentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentDetails(int id)
        {
            var studentDetails = await _context.StudentDetailsTraining.FindAsync(id);
            if (studentDetails == null)
            {
                return NotFound();
            }

            _context.StudentDetailsTraining.Remove(studentDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentDetailsExists(int id)
        {
            return _context.StudentDetailsTraining.Any(e => e.id == id);
        }
    }
}
