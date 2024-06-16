using System;
using System.Collections.Generic;

namespace ManageStudent.Models
{
    public partial class SubjectLecturer
    {
        public int SubjectLecturerId { get; set; }
        public int? SubjectId { get; set; }
        public int? LecturerId { get; set; }

        public virtual Lecturer? Lecturer { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
