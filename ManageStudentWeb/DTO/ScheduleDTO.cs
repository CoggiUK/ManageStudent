namespace ManageStudent.DTO
{
    public class ScheduleDTO
    {
        public int ScheduleId { get; set; }
        public string? SubjectName { get; set; }
        public string? SemesterName { get; set; }
        public string DayOfWeek { get; set; } = null!;
        public int Slot { get; set; }
        public string Room { get; set; } = null!;


    }
}
