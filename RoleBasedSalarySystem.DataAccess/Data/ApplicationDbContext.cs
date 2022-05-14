using Microsoft.EntityFrameworkCore;
using RoleBasedSalarySystem.DataAccess.Entities;

namespace RoleBasedSalarySystem.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Work> Work { get; set; }
    }
}
