using System.ComponentModel.DataAnnotations.Schema;

namespace CRECT2.Models
{
    public class CorseResult
    {
        public int ID { get; set; }
        public float Degree { get; set; }
        [ForeignKey("Course")]
        public int CorsId { get; set; }
        [ForeignKey("Trainee")]
        public int TranId { get; set; }
        public Course? Course { get; set; }
        public Trainee? Trainee { get; set; }
    }
}
