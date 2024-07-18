using System;
using System.Collections.Generic;

<<<<<<< HEAD
namespace ManageStudentWeb.Models
=======
namespace ManageStudent.Models
>>>>>>> main
{
    public partial class Schedule
    {
        public Schedule()
        {
            LecturerSchedules = new HashSet<LecturerSchedule>();
            StudentSchedules = new HashSet<StudentSchedule>();
        }

        public int ScheduleId { get; set; }
        public int? SubjectId { get; set; }
        public int? SemesterId { get; set; }
        public string DayOfWeek { get; set; } = null!;
        public int Slot { get; set; }
        public string Room { get; set; } = null!;

        public virtual Semester? Semester { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual ICollection<LecturerSchedule> LecturerSchedules { get; set; }
        public virtual ICollection<StudentSchedule> StudentSchedules { get; set; }
    }
}
