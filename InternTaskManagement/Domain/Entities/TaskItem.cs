using InternTaskManagement.Domain.Enums;

namespace InternTaskManagement.Domain.Entities
{

    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Enums.TaskStatus Status { get; set; } = Enums.TaskStatus.Todo;

        public Enums.TaskPriority Priority { get; set; } = Enums.TaskPriority.Medium;

        public Guid ProjectId { get; set; }

        public Guid? AssignedToUserId { get; set; }
        public User? AssignedToUser { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? CompletedAt { get; set; }

        public Project Project { get; set; }
        public ICollection<TaskHistory> TaskHistories { get; set; } = new List<TaskHistory>();
    }
}
