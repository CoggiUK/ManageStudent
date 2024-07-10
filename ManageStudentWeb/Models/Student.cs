using System;
using System.Collections.Generic;

namespace ManageStudent.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
            StudentSchedules = new HashSet<StudentSchedule>();
        }

        public int StudentId { get; set; }
        public int? AccountId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual Account? Account { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<StudentSchedule> StudentSchedules { get; set; }
    }
}
