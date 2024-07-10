using System;
using System.Collections.Generic;

namespace ManageStudent.Models
{
    public partial class Account
    {
        public Account()
        {
            Lecturers = new HashSet<Lecturer>();
            Students = new HashSet<Student>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;

        public virtual ICollection<Lecturer> Lecturers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
