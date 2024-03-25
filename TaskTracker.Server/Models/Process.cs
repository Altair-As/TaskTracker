namespace TaskTracker.Server.Models
{
    public class Process
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        public List<Employee> ? Employees { get; set; }

        public List<TaskTracker.Server.Models.Task> ? MyProperty { get; set; }
    }
}
