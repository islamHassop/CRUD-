using System.ComponentModel.DataAnnotations;

namespace CRECT2.Models
{
    public class Department
    {
        public int ID { get; set; }
        [Required]
        [MinLength(3)]
        public string? Name { get; set; }
        [Required]
        [MinLength(3)]
        public string?  Manager { get; set; }
        public List<Employee>? employees { get; set; }
        public List<Course>? courses { get; set; }
        public List<Trainee>? trainees { get; set; }
    }
}
