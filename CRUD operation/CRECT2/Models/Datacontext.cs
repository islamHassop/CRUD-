
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRECT2.Models
{
    public class Datacontext : IdentityDbContext 
    {
        public Datacontext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }  
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
    
    }
   


}
