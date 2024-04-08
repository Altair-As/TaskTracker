using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaskTracker.Server.Data;


namespace TaskTracker.Server.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        [Required]
        public required string Email { get; set; }

        public string ? Ocupation { get; set; }

        public int DepartmentId { get; set; }
        public Department ? Department { get; set; }

        [JsonIgnore]
        public List<Process> ? Processes { get; set; }

        public ApplicationUser ? User { get; set; }
    }
}
