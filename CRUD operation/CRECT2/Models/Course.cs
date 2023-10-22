using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRECT2.Models
{
    public class Course
    {
        public int ID { get; set; }
        //[Required]
        //[MinLength(2)]
        public string? Name { get; set; }
      
        public int Degree { get; set; }
       
        public int Min_Degree { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public Department? Department { get; set; }
        public List<Employee>? employees { get; set; }
        public List<CorseResult>? corseResults { get; set; }


    }
}
