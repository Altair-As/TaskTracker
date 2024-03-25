using Microsoft.AspNetCore.Identity;
using TaskTracker.Server.Models;

namespace TaskTracker.Server.Data
{
    public class ApplicationUser : IdentityUser
    {
        public int EmployeeId { get; set; }
        public Employee ? Employee { get; set; }
    }
}
