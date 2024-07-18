using System;
using System.Collections.Generic;

<<<<<<< HEAD
namespace ManageStudentWeb.Models
=======
namespace ManageStudent.Models
>>>>>>> main
{
    public partial class LecturerSchedule
    {
        public int LecturerScheduleId { get; set; }
        public int? LecturerId { get; set; }
        public int? ScheduleId { get; set; }

        public virtual Lecturer? Lecturer { get; set; }
        public virtual Schedule? Schedule { get; set; }
    }
}
