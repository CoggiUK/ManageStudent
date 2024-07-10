using System;
using System.Collections.Generic;

namespace ManageStudent.Models
{
    public partial class Grade
    {
        public int GradeId { get; set; }
        public int? StudentId { get; set; }
        public int? SubjectId { get; set; }
        public int? SemesterId { get; set; }
        public decimal? Grade1 { get; set; }

        public virtual Semester? Semester { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
