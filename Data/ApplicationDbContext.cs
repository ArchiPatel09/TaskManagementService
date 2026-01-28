using Microsoft.EntityFrameworkCore;
using TaskManagementService.Models;

namespace TaskManagementService.Data
{
    // database context for the task management service
    public class ApplicationDbContext : DbContext
    {
        // constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // dbSet for TaskItems
        public DbSet<TaskItem> TaskItems { get; set; }

        // configuring model properties and seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskItem>().Property(t => t.Priority)
                .HasConversion<int>();

            modelBuilder.Entity<TaskItem>().Property(t => t.Status)
                .HasConversion<int>();

            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem
                {
                    Id = 1,
                    Title = "Learn Supervised Machine Learning",
                    Description = "Create house price prediction model using supervised machine learning techniques.",
                    Priority = TaskItem.TaskPriority.Medium,
                    Status = TaskItem.TaskStatus.InProgress,
                    DueDate = DateTime.UtcNow.AddDays(4),
                    EstimatedHours = 13,
                    CreatedAt = DateTime.UtcNow.AddDays(-2),
                    UpdatedAt = DateTime.UtcNow.AddDays(-1)
                },
                new TaskItem
                {
                    Id = 2,
                    Title = "Complete Python Data Analysis Project",
                    Description = "Analyze sales data using Python libraries such as Pandas and Matplotlib. Then use the data in one of frontend projects.",
                    Priority = TaskItem.TaskPriority.High,
                    Status = TaskItem.TaskStatus.Pending,
                    DueDate = DateTime.UtcNow.AddDays(7),
                    EstimatedHours = 20,
                    CreatedAt = DateTime.UtcNow.AddDays(-1),
                    UpdatedAt = null
                },
                new TaskItem
                {
                    Id = 3,
                    Title = "Create one full-stack project by using ASP.NET Core and React!",
                    Description = "Develop a full-stack web application using ASP.NET Core for the backend and React for the frontend. Implement CRUD operations and user authentication.",
                    Priority = TaskItem.TaskPriority.Critical,
                    Status = TaskItem.TaskStatus.Pending,
                    DueDate = DateTime.UtcNow.AddDays(3),
                    EstimatedHours = 15,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = null
                }
            );
        }   
    }
}