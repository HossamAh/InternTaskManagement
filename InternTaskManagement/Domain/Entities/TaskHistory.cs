namespace InternTaskManagement.Domain.Entities
{
    public class TaskHistory
    {
        public Guid Id { get; set; }
        public Guid TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }
        public string Action { get; set; }= string.Empty;
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
