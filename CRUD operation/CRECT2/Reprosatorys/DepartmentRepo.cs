using CRECT2.Interface;
using CRECT2.Models;
using CRECT2.ViewModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CRECT2.Reprosatorys
{
    public class DepartmentRepo : G_Interface<Department>, VM_Interface_<Emp_For_Dept>
    {
        Datacontext DeptRepo;
        public DepartmentRepo(Datacontext _DeptRepo)
        {
            DeptRepo = _DeptRepo;
        }
        public void Create(Department item)
        {
            DeptRepo.Departments.Add(item);
            DeptRepo.SaveChanges();
        }
        public void Delete(int id)
        {
            var Dept = DeptRepo.Departments.Find(id);
            DeptRepo.Departments.Remove(Dept);
            DeptRepo.SaveChanges();
        }

        public Department Edite(Department item, int id)
        {
            Department Dept = DeptRepo.Departments.FirstOrDefault(d=>d.ID==item.ID);
           
                Dept.Name = item.Name;
                Dept.Manager = item.Manager;    
               
          
            DeptRepo.SaveChanges();
            return Dept;
        }

      

        public List<Department> GetAll() 
        {
            List<Department> Dept = DeptRepo.Departments.ToList();
            return Dept;
        }

        public Department GetById(int id)
        {
            Department Dept = DeptRepo.Departments.Find(id);
            return Dept;
        }

        public Department GetByName(string name)
        {
            Department Dept = DeptRepo.Departments.FirstOrDefault(e => e.Name == name);
            return Dept;
        }
        public List<Emp_For_Dept> EmpDept()
        {
            List<Emp_For_Dept> depts = new List<Emp_For_Dept>();
            foreach(var item in DeptRepo.Departments.ToList())
            {
                Emp_For_Dept depts1= new Emp_For_Dept() ;
                depts1.ID = item.ID;
                depts1.Name = item.Name;
                depts1.Maneger = item.Manager;
                depts1.employees=DeptRepo.Employees.Where(e=>e.DeptId==item.ID).Include(nameof(Course)).ToList();   
                depts.Add(depts1);
            }
            return depts;
        }

      
    }
}
