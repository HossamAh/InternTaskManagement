using InternTaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternTaskManagement.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        // DI injects options (connection string)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();

        public DbSet<Project> Projects => Set<Project>();
        public DbSet<TaskItem> TaskItems => Set<TaskItem>();
        public DbSet<TaskHistory> TaskHistories => Set<TaskHistory>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}
