using System;
using System.Collections.Generic;

namespace ManageStudent.Models
{
    public partial class Lecturer
    {
        public Lecturer()
        {
            LecturerSchedules = new HashSet<LecturerSchedule>();
            SubjectLecturers = new HashSet<SubjectLecturer>();
        }

        public int LecturerId { get; set; }
        public int? AccountId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Department { get; set; }

        public virtual Account? Account { get; set; }
        public virtual ICollection<LecturerSchedule> LecturerSchedules { get; set; }
        public virtual ICollection<SubjectLecturer> SubjectLecturers { get; set; }
    }
}
