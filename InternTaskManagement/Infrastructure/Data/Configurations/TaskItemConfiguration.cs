using InternTaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternTaskManagement.Infrastructure.Data.Configurations
{
    public class TaskItemConfiguration: IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).IsRequired().HasMaxLength(200);
            builder.Property(t => t.Description).IsRequired().HasMaxLength(1000);
            builder.Property(t => t.Status).IsRequired().HasConversion<int>().HasMaxLength(50);
            builder.Property(t => t.Priority).IsRequired().HasConversion<int>().HasMaxLength(50);
            builder.Property(t => t.DueDate).IsRequired(false);
            builder.Property(t => t.CreatedAt).IsRequired();
            builder.Property(t => t.CompletedAt).IsRequired(false);


            // Relationships
            builder.HasMany(ti => ti.TaskHistories)
                .WithOne(th => th.TaskItem)
                .HasForeignKey(th => th.TaskItemId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
