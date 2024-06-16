using System;
using System.Collections.Generic;

namespace ManageStudent.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Grades = new HashSet<Grade>();
            Schedules = new HashSet<Schedule>();
            SubjectLecturers = new HashSet<SubjectLecturer>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = null!;
        public int Credits { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<SubjectLecturer> SubjectLecturers { get; set; }
    }
}
