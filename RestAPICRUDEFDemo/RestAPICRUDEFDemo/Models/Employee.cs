using System;
using System.ComponentModel.DataAnnotations;

namespace RestAPICRUDEFDemo.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="Name cannot be more than 50 chars")]
        public string Name { get; set; }
    }
}
