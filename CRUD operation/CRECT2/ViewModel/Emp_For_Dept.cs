using CRECT2.Models;

namespace CRECT2.ViewModel
{
    public class Emp_For_Dept 
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Maneger { get; set; }
        public List<Employee>? employees { get; set; } 
        public List<Department>? departments { get; set; }
        public List<Course>? courses { get; set; } 
    }
}
