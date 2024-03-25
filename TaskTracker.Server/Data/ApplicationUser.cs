using Microsoft.AspNetCore.Identity;
using TaskTracker.Server.Models;

namespace TaskTracker.Server.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Username { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
