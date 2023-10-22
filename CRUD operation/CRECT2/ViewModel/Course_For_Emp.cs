using CRECT2.Models;
using System.ComponentModel.DataAnnotations;

namespace CRECT2.ViewModel
{
    public class Course_For_Emp
    {
        public int ID { get; set; }
        [MinLength(3)]
        [Required]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public int Degree { get; set; }
        [Required, Range(50, 100)]
        public int Min_Degree { get; set; }
        public List<Employee>? Employees { get; set; }
        public List<Trainee>? Trainees { get; set; }
        public List<Department>? Departments { get; set; }
        public List<CorseResult>? corseResults { get; set; }
    }
}
