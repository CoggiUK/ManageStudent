using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ManageStudent.Models
{
    public partial class ManageStudentContext : DbContext
    {
        public ManageStudentContext()
        {
        }

        public ManageStudentContext(DbContextOptions<ManageStudentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Lecturer> Lecturers { get; set; } = null!;
        public virtual DbSet<LecturerSchedule> LecturerSchedules { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Semester> Semesters { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentSchedule> StudentSchedules { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<SubjectLecturer> SubjectLecturers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = config["ConnectionStrings:MyDatabase"];
            optionsBuilder.UseSqlServer(strConn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => e.Username, "UQ__Account__536C85E4515F7EA0")
                    .IsUnique();

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.GradeId).HasColumnName("GradeID");

                entity.Property(e => e.Grade1)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("Grade");

                entity.Property(e => e.SemesterId).HasColumnName("SemesterID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK__Grades__Semester__5AEE82B9");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Grades__StudentI__59063A47");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Grades__SubjectI__59FA5E80");
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Lecturer__A9D10534DD38A7F2")
                    .IsUnique();

                entity.Property(e => e.LecturerId).HasColumnName("LecturerID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Department)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Lecturers)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Lecturers__Accou__403A8C7D");
            });

            modelBuilder.Entity<LecturerSchedule>(entity =>
            {
                entity.ToTable("LecturerSchedule");

                entity.Property(e => e.LecturerScheduleId).HasColumnName("LecturerScheduleID");

                entity.Property(e => e.LecturerId).HasColumnName("LecturerID");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.LecturerSchedules)
                    .HasForeignKey(d => d.LecturerId)
                    .HasConstraintName("FK__LecturerS__Lectu__5441852A");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.LecturerSchedules)
                    .HasForeignKey(d => d.ScheduleId)
                    .HasConstraintName("FK__LecturerS__Sched__5535A963");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.DayOfWeek)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Room)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SemesterId).HasColumnName("SemesterID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK__Schedule__Semest__4D94879B");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Schedule__Subjec__4CA06362");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.Property(e => e.SemesterId).HasColumnName("SemesterID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.SemesterName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.HasIndex(e => e.Email, "UQ__Student__A9D10534A358BE3A")
                    .IsUnique();

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Student__Account__3C69FB99");
            });

            modelBuilder.Entity<StudentSchedule>(entity =>
            {
                entity.ToTable("StudentSchedule");

                entity.Property(e => e.StudentScheduleId).HasColumnName("StudentScheduleID");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.StudentSchedules)
                    .HasForeignKey(d => d.ScheduleId)
                    .HasConstraintName("FK__StudentSc__Sched__5165187F");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentSchedules)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentSc__Stude__5070F446");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubjectLecturer>(entity =>
            {
                entity.ToTable("SubjectLecturer");

                entity.Property(e => e.SubjectLecturerId).HasColumnName("SubjectLecturerID");

                entity.Property(e => e.LecturerId).HasColumnName("LecturerID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.SubjectLecturers)
                    .HasForeignKey(d => d.LecturerId)
                    .HasConstraintName("FK__SubjectLe__Lectu__45F365D3");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectLecturers)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__SubjectLe__Subje__44FF419A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
