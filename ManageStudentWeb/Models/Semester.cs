using System;
using System.Collections.Generic;

namespace ManageStudent.Models
{
    public partial class Semester
    {
        public Semester()
        {
            Grades = new HashSet<Grade>();
            Schedules = new HashSet<Schedule>();
        }

        public int SemesterId { get; set; }
        public string SemesterName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
