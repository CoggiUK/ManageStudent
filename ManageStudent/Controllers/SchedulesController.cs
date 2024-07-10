using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManageStudent.Models;
using ManageStudent.DTO;

namespace ManageStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly ManageStudentContext _context;

        public SchedulesController(ManageStudentContext context)
        {
            _context = context;
        }

        // GET: api/Schedules
        [HttpGet]
        public ActionResult GetSchedules()
        {
          var schedules = _context.Schedules.Include(s => s.Semester).Include(s => s.Subject).Select(s => new ScheduleDTO
          {
              ScheduleId = s.ScheduleId,
              DayOfWeek = s.DayOfWeek,
              Room = s.Room,
              SemesterName = s.Semester.SemesterName,
              Slot = s.Slot,
              SubjectName = s.Subject.SubjectName
          }).ToList();
            return Ok(schedules);
        }

        // GET: api/Schedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetSchedule(int id)
        {
          if (_context.Schedules == null)
          {
              return NotFound();
          }
            var schedule = await _context.Schedules.FindAsync(id);

            if (schedule == null)
            {
                return NotFound();
            }

            return schedule;
        }

        [HttpGet("FindbySemeter/{id}")]
        public async Task<ActionResult<Schedule>> FindbySemeter(int id)
        {
            if (_context.Schedules == null)
            {
                return NotFound();
            }
            var schedule =  _context.Schedules.Where(s => s.SemesterId == id).ToList();

            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule);
        }

        // PUT: api/Schedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchedule(int id, Schedule schedule)
        {
            if (id != schedule.ScheduleId)
            {
                return BadRequest();
            }

            _context.Entry(schedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleExists(id))
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

        // POST: api/Schedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Schedule>> PostSchedule(Schedule schedule)
        {
          if (_context.Schedules == null)
          {
              return Problem("Entity set 'ManageStudentContext.Schedules'  is null.");
          }
            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchedule", new { id = schedule.ScheduleId }, schedule);
        }

        // DELETE: api/Schedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            if (_context.Schedules == null)
            {
                return NotFound();
            }
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleExists(int id)
        {
            return (_context.Schedules?.Any(e => e.ScheduleId == id)).GetValueOrDefault();
        }
    }
}
