using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRECT2.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Required]
        [MinLength(3)]
        public string? Name { get; set; }
        [Required,Range(3000,10000)]
        public decimal Salary { get; set; }
        [Required]
        [MinLength(3)]
        public string? Address { get; set; }
        public string? Image { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public Department? Department { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
       
        public Course? Course { get; set; }
    }
}
