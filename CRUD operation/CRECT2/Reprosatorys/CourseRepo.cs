using CRECT2.Interface;
using CRECT2.Models;
using CRECT2.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace CRECT2.Reprosatorys
{
    public class CourseRepo : G_Interface<Course>, Interface_Segragation<Course>,VMCours_Interface<Course_For_Emp>
    {
        Datacontext RepoCrs;

        public CourseRepo(Datacontext _RepoCrs)
        {
            RepoCrs = _RepoCrs;
        }

    

        public void Create(Course item)
        {
            RepoCrs.Courses.Add(item);
            RepoCrs.SaveChanges();
        }

        public void Delete(int id)
        {
            Course crs= RepoCrs.Courses.FirstOrDefault(c => c.ID == id);
           
                RepoCrs.Courses.Remove(crs);
                  RepoCrs.SaveChanges();
        }

        public Course Edite(Course item, int id)
        {
            var crs = RepoCrs.Courses.FirstOrDefault(c => c.ID == id);
            if(crs!= null)
            {
                crs.Name = item.Name;
                crs.Degree=item.Degree;
                crs.Min_Degree=item.Min_Degree;
                crs.DeptId=item.DeptId;
                RepoCrs.SaveChanges();
            }
            
            return crs;
        }

       

        public List<Course> GetAll()
        {
            var crs = RepoCrs.Courses.ToList();
            return crs;
        }

        public Course GetById(int id)
        {
            var crs = RepoCrs.Courses.Find(id);
            return crs;
        }

        public Course GetByName(string name)
        {
            var crs = RepoCrs.Courses.FirstOrDefault(c => c.Name == name);
            return crs;
        }

     

        public List<Course> GetItemByIdDept(int DeptId)
        {
            var crs = RepoCrs.Courses.Where(c => c.DeptId == DeptId).Include(nameof(Department)).ToList();
            return crs;
        }
        public List<Course_For_Emp> Cours_Emp()
        {
            List<Course_For_Emp> course_For_Emps = new List<Course_For_Emp>();
            foreach (var item in RepoCrs.Courses.ToList())
            {
                Course_For_Emp CorsEmp = new Course_For_Emp();
                CorsEmp.ID = item.ID;
                CorsEmp.Name = item.Name;
                CorsEmp.Degree = item.Degree;
                CorsEmp.Min_Degree = item.Min_Degree;
                CorsEmp.Employees = RepoCrs.Employees.Where(e => e.CourseId == item.ID).Include(nameof(Department)).ToList();
                course_For_Emps.Add(CorsEmp);  
            }
            return course_For_Emps;
        }

    }
}
