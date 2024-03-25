namespace TaskTracker.Server.Models
{
    public class History
    {
        public int Id { get; set; }
        public required string Action { get; set; }

        public int TaskId { get; set; }
        public Task ? Task { get; set; }

        public DateTime ActionTime { get; set; } = DateTime.Now;
    }
}
