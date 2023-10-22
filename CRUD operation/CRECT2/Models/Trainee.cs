using System.ComponentModel.DataAnnotations.Schema;

namespace CRECT2.Models
{
    public class Trainee
    {
        public int ID { get; set; }
        public  string? Name { get; set; }
        public string? Address { get; set; }
        public string? Imag { get; set; }
        public string? grade { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public List<CorseResult>? corseResults { get; set; }
        public Department? Department { get; set; }

    }
}
