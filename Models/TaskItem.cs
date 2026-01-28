using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementService.Models
{
    // Represents a task item in the task management system
    public class TaskItem
    {
        // primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // title of the task
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 150 characters.")]
        public string Title { get; set; } = string.Empty;

        // description of the task
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(650, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 650 characters.")]  
        public string Description { get; set; } = string.Empty;

        // priority of the task
        [Required]
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        // status of the task
        [Required]
        public TaskStatus Status { get; set; } = TaskStatus.Pending;

        // due date of the task
        [Required]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Due date must be a future date.")]
        public DateTime? DueDate { get; set; }

        // estimated hours to complete the task
        [Range(1, 100, ErrorMessage = "Estimated hours must be between 1 and 100.")]
        public int EstimatedHours { get; set; }

        // timestamps
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        // enuums for task priority and status
        public enum TaskPriority
        {
            Low,
            Medium,
            High,
            Critical
        }

        // enums for task status
        public enum TaskStatus
        {
            Pending = 1,
            InProgress = 2,
            Completed = 3,
            Cancelled = 5
        }

        // custom validation attribute to ensure due date is in the future
        public class FutureDateAttribute : ValidationAttribute
        {
           public override bool IsValid(object? value)
           {
               if (value is DateTime dateValue)
               {
                   return dateValue > DateTime.UtcNow.Date;
               }
               return false;
           }
        }
    }
}