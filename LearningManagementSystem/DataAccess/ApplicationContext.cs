using LearningManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
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
            modelBuilder.Entity<User>()
                        .HasIndex(u => u.Email)
                        .IsUnique();
        }
    }
}
