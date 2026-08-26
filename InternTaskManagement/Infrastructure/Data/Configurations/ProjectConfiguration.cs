using InternTaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternTaskManagement.Infrastructure.Data.Configurations
{
    public class ProjectConfiguration:IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
            builder.Property(p => p.StartDate).IsRequired();
            builder.Property(p => p.Status).IsRequired().HasConversion<int>().HasMaxLength(50);
            builder.Property(p => p.EndDate).IsRequired(false);
            builder.Property(p => p.CreatedAt).IsRequired();

            //relationships
            builder.HasMany(p => p.Tasks)
                   .WithOne(t => t.Project)
                   .HasForeignKey(t => t.ProjectId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
