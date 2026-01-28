using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementService.Models
{
    public class TaskItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 150 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(650, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 650 characters.")]  
        public string Description { get; set; } = string.Empty;

        [Required]
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        [Required]
        public TaskStatus Status { get; set; } = TaskStatus.Pending;

        [Required]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Due date must be a future date.")]
        public DateTime? DueDate { get; set; }

        [Range(1, 100, ErrorMessage = "Estimated hours must be between 1 and 100.")]
        public int EstimatedHours { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        public enum TaskPriority
        {
            Low,
            Medium,
            High,
            Critical
        }

        public enum TaskStatus
        {
            Pending = 1,
            InProgress = 2,
            Completed = 3,
            Cancelled = 5
        }

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