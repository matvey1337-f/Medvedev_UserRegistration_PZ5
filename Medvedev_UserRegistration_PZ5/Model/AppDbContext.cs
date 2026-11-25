using System.Data.Entity;

namespace Medvedev_UserRegistration_PZ5.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=DefaultConnection")
        {
        }
        public DbSet<User> Users { get; set; }
    }
}