using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManageStudent.Models;

namespace ManageStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturersController : ControllerBase
    {
        private readonly ManageStudentContext _context;

        public LecturersController(ManageStudentContext context)
        {
            _context = context;
        }

        // GET: api/Lecturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lecturer>>> GetLecturers()
        {
          if (_context.Lecturers == null)
          {
              return NotFound();
          }
            return await _context.Lecturers.ToListAsync();
        }

        // GET: api/Lecturers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lecturer>> GetLecturer(int id)
        {
          if (_context.Lecturers == null)
          {
              return NotFound();
          }
            var lecturer = await _context.Lecturers.FindAsync(id);

            if (lecturer == null)
            {
                return NotFound();
            }

            return lecturer;
        }
        
        private bool LecturerExists(int id)
        {
            return (_context.Lecturers?.Any(e => e.LecturerId == id)).GetValueOrDefault();
        }
    }
}
