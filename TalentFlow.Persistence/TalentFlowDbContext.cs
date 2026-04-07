using Microsoft.EntityFrameworkCore;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Persistence
{
    public class TalentFlowDbContext : DbContext
    {
        public TalentFlowDbContext(DbContextOptions<TalentFlowDbContext> options)
            : base(options)
        {
        }

        // DbSets for all aggregates
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;
        public DbSet<Enrollment> Enrollments { get; set; } = null!;
        public DbSet<Instructor> Instructors { get; set; } = null!;
        public DbSet<Assessment> Assessments { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<AuditLog> AuditLogs { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;

        // Newly added aggregates
        public DbSet<Progress> Progresses { get; set; } = null!;
        public DbSet<Lesson> Lessons { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<Certificate> Certificates { get; set; } = null!;
        public DbSet<Video> Videos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // No foreign keys or auto mapping
            // Each aggregate is independent
            modelBuilder.Entity<Course>().Ignore(c => c.Enrollments); // handled manually
            modelBuilder.Entity<Assessment>().Ignore(a => a.Questions); // handled manually
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TalentFlowDbContext).Assembly);
        }
    }
}
