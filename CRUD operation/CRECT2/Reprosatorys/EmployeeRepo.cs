using CRECT2.Interface;
using CRECT2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CRECT2.Reprosatorys
{

    public class EmployeeRepo : G_Interface<Employee>
    {
         Datacontext EmpRepo;
        public EmployeeRepo(Datacontext _EmpRepo)
        {
            EmpRepo = _EmpRepo;
        }

        public List<Employee> GetAll()
        {
            List<Employee> emp = EmpRepo.Employees.Include("Department").Include("Course").ToList();
            return emp;
        }
        public Employee GetById(int id)
        {
            Employee emp = EmpRepo.Employees.Find(id);
            return emp;
        }
        public Employee GetByName(string name)
        {
            Employee emp =EmpRepo.Employees.FirstOrDefault(e=>e.Name==name);
            return emp;
        }
        public void Create(Employee employee)
        {
            
                EmpRepo.Employees.Add(employee);
                EmpRepo.SaveChanges();
         
          
        }
        public Employee Edite(Employee employee,int id) 
        {
            //get oldemp
            Employee emp=EmpRepo.Employees.FirstOrDefault(e => e.ID == id);
            if(emp != null)
            {
                emp.Name = employee.Name;
                emp.Address = employee.Address;
                emp.Salary = employee.Salary;
                emp.DeptId = employee.DeptId;
                emp.CourseId = employee.CourseId;
                emp.Image = employee.Image;
                EmpRepo.SaveChanges();
            }
           
            return emp;
        }
        public void Delete(int id) 
        {
          var x =   EmpRepo.Employees.Find(id);
            var emp = EmpRepo.Employees.Remove(x);
            EmpRepo.SaveChanges();
        }
    }
}
