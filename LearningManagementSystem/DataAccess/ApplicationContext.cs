using LearningManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Models.File> Files { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public ApplicationContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.sqlite");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                        .HasOne(c => c.Author)
                        .WithMany(u => u.Courses)
                        .HasForeignKey(c => c.AuthorId)
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Course>()
                        .HasMany(c => c.Users)
                        .WithMany(u => u.EnrolledCourses);
            modelBuilder.Entity<Course>()
                        .HasMany(c => c.Lessons)
                        .WithOne(l => l.Course)
                        .HasForeignKey(l => l.CourseId)
                        .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<User>()
                        .HasIndex(u => u.Email)
                        .IsUnique();
            modelBuilder.Entity<Lesson>()
                        .HasMany(l => l.AttachedFiles);
            modelBuilder.Entity<Role>()
                        .HasMany(r => r.Permissions)
                        .WithMany(p => p.Roles);
        }
    }
}
