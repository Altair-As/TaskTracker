using System.Text.Json.Serialization;

namespace TaskTracker.Server.Models
{
    public class Department
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        [JsonIgnore]
        public List<Employee> ? Employees { get; set; }
    }
}
