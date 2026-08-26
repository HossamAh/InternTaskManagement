using InternTaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace InternTaskManagement.Infrastructure.Data.Configurations
{
    public class TaskHistoryConfiguration:IEntityTypeConfiguration<TaskHistory>
    {
        public void Configure(EntityTypeBuilder<TaskHistory> builder)
        {
            builder.HasKey(th => th.Id);

            builder.Property(th => th.Action).IsRequired().HasMaxLength(100);
            builder.Property(th => th.OldValue).HasMaxLength(500).IsRequired(false);
            builder.Property(th => th.NewValue).HasMaxLength(500).IsRequired(false);
            builder.Property(th => th.CreatedAt).IsRequired();

            builder.HasOne(th => th.TaskItem)
                   .WithMany(ti => ti.TaskHistories)
                   .HasForeignKey(th => th.TaskItemId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
