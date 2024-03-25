using TaskTracker.Server.Data;

namespace TaskTracker.Server.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string ? Ocupation { get; set; }

        public int DepartmentId { get; set; }
        public Department ? Department { get; set; }

        public List<Process> ? Processes { get; set; }

        public ApplicationUser ? User { get; set; }
    }
}
