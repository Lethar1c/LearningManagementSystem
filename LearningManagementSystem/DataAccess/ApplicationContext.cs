using LearningManagementSystem.DataAccess.Users;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.sqlite");
        }
    }
}
