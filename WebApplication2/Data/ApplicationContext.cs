using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
namespace WebApplication2.NewFolder
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}
