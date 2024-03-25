namespace TaskTracker.Server.Models
{
    public class Task
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = String.Empty;
        public Statuses Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int Priority { get; set; }

        public int ProcessId { get; set; }
        public Process ? Process { get; set; }

        public List<History> ? Histories { get; set; }
    }

    public enum Statuses
    {
        Fixed,
        Underway,
        Fulfilled,
        Hold,
        Controlled
    }
}
