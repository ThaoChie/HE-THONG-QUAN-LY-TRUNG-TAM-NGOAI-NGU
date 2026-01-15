using LCenterDAL.Entities;
using LCenterDAL.DTOs;
using Microsoft.EntityFrameworkCore;

namespace LCenterDAL.Context
{
    public class LCenterContext : DbContext
    {
        public LCenterContext(DbContextOptions<LCenterContext> options) : base(options) { }
        public LCenterContext() { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Score> Scores { get; set; }

        public DbSet<Attendance> Attendances { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassDTO>().HasNoKey();
            modelBuilder.Entity<StatisticDTO>().HasNoKey();
            modelBuilder.Entity<EnrollmentDTO>().HasNoKey();
            modelBuilder.Entity<ScoreDTO>().HasNoKey();
            modelBuilder.Entity<AttendanceDTO>().HasNoKey();
        }
    }
}