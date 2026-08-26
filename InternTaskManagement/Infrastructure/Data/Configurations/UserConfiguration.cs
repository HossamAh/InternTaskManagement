using InternTaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace InternTaskManagement.Infrastructure.Data.Configurations
{
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FullName).IsRequired().HasMaxLength(150);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Role).IsRequired().HasMaxLength(50);
            builder.Property(u => u.CreatedAt).IsRequired();

            builder.HasMany(u => u.AssignedTasks)
                   .WithOne(ti => ti.AssignedToUser)
                   .HasForeignKey(ti => ti.AssignedToUserId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
