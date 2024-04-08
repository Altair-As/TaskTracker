using System.Text.Json.Serialization;

namespace TaskTracker.Server.Models
{
    public class Process
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Employee> ? Employees { get; set; }

        [JsonIgnore]
        public List<TaskTracker.Server.Models.Task> ? Tasks { get; set; }
    }
}
