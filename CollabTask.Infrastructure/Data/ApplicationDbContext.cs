using CollabTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollabTask.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<TodoTask> TodoTasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasMany(p => p.Tasks)
                .WithOne()
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

                // Cach 1
                entity.Navigation(p => p.Tasks)
                .HasField("_tasks")
                .UsePropertyAccessMode(PropertyAccessMode.Field);

                // Cach 2
                // entity.Metadata.FindNavigation(nameof(Project.Tasks))!
                // .SetPropertyAccessMode(PropertyAccessMode.Field);
            });
        }
    }
}