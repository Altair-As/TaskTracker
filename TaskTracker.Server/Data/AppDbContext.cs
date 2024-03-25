using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Server.Models;

namespace TaskTracker.Server.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<History> Histories { get; set; }
    }
}
