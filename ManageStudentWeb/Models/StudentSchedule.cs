using System;
using System.Collections.Generic;

namespace ManageStudent.Models
{
    public partial class StudentSchedule
    {
        public int StudentScheduleId { get; set; }
        public int? StudentId { get; set; }
        public int? ScheduleId { get; set; }

        public virtual Schedule? Schedule { get; set; }
        public virtual Student? Student { get; set; }
    }
}
