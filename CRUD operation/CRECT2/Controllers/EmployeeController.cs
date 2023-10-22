using CRECT2.Interface;
using CRECT2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CRECT2.Controllers
{
    public class EmployeeController : Controller
    {
        G_Interface<Employee> Empinterface;
        G_Interface<Department> Deptinterface;
        G_Interface<Course> Crsinterface;
        Interface_Segragation<Course> CrsDept;
        public EmployeeController(G_Interface<Employee> _Employee, G_Interface<Department> _Department
                , G_Interface<Course> _Courses, Interface_Segragation<Course> _CrsDept)
        {
            Empinterface = _Employee;   
            Deptinterface = _Department;
            Crsinterface= _Courses;
            CrsDept = _CrsDept;

        }
        //public EmployeeController(Datacontext _context) 
        //{
        //    context = _context;
        //}
        public IActionResult ShowAll()
        {

            var employees = Empinterface.GetAll();
            return View(employees);
        }
        [HttpGet]

        public IActionResult AddItem()
        {
          var x=  new SelectList(Deptinterface.GetAll(), nameof(Department.ID), nameof(Department.Name));
            ViewBag.ListDept = x;

           var y=  new SelectList(Crsinterface.GetAll(), nameof(Course.ID), nameof(Course.Name));
            ViewBag.ListCrs = y;
               
           
        
                return View(new Employee());
          
        }
        [HttpPost]
       
        public IActionResult AddItem(Employee emp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData["ADD"] = emp.Name;
                    Empinterface.Create(emp);
                    return RedirectToAction("ShowAll");
                }
                catch (Exception ex)
                {
                    ViewBag.ListDept = new SelectList(Deptinterface.GetAll(), nameof(Department.ID), nameof(Department.Name));
                    

                    ViewBag.ListCrs = new SelectList(Crsinterface.GetAll(), nameof(Course.ID), nameof(Course.Name));
                   

                    ModelState.AddModelError("Database", "error in data " + ModelState);
                    return View(emp);
                }
            }

            var x = new SelectList(Deptinterface.GetAll(), nameof(Department.ID), nameof(Department.Name));
            ViewBag.ListDept = x;

            var y = new SelectList(Crsinterface.GetAll(), nameof(Course.ID), nameof(Course.Name));
            ViewBag.ListCrs = y;


            return View(emp);

        }
        [HttpGet]
       
        public IActionResult UpdateItem(int id)
        {
           Employee emp= Empinterface.GetById(id);
            var x =new SelectList(Deptinterface.GetAll(), nameof(Department.ID), nameof(Department.Name),emp.DeptId);
            ViewBag.ListDept = x;
            var y= new SelectList(Crsinterface.GetAll(), nameof(Course.ID), nameof(Course.Name),emp.CourseId);
            ViewBag.ListCors = y;
            return View(emp);
        }
        [HttpPost]
       
        public IActionResult UpdateItem(Employee emp)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    TempData["Edite"] = emp.Name;
                    Empinterface.Edite(emp, emp.ID);
                    return RedirectToAction("ShowAll");

                }
                catch (Exception ex)
                {
                    ViewBag.ListDept = new SelectList(Deptinterface.GetAll(), nameof(Department.ID), nameof(Department.Name), emp.DeptId);

                    ViewBag.ListCors = new SelectList(Crsinterface.GetAll(), nameof(Course.ID), nameof(Course.Name), emp.CourseId);
                     
                    ModelState.AddModelError("Datebase", "error from" + ModelState+ex);
                  

                }
                ViewBag.ListDept = new SelectList(Deptinterface.GetAll(), nameof(Department.ID), nameof(Department.Name), emp.DeptId);

                ViewBag.ListCors = new SelectList(Crsinterface.GetAll(), nameof(Course.ID), nameof(Course.Name), emp.CourseId);

                ModelState.AddModelError("Datebase", "error from" + ModelState);
                return View(emp);

            }
            var x = new SelectList(Deptinterface.GetAll(), nameof(Department.ID), nameof(Department.Name), emp.DeptId);
            ViewBag.ListDept = x;
            var y = new SelectList(Crsinterface.GetAll(), nameof(Course.ID), nameof(Course.Name), emp.CourseId);
            ViewBag.ListCors = y;
            ModelState.AddModelError("Datebase", "error from" + ModelState);
            return View(emp);
        }
        public IActionResult DeleteItem(int id)
        {
            var x =Empinterface.GetById(id);
            TempData["Delete"] = x.Name;
            Empinterface.Delete(id);
            return RedirectToAction("ShowAll");
        }
        public IActionResult DetailsItem(int id) 
        {
            
           var emp= Empinterface.GetById(id);
            ViewData["D_Emp"] = new SelectList(Deptinterface.GetAll(), "ID", "Name", emp.DeptId);
            ViewData["C_Emp"] = new SelectList(Crsinterface.GetAll(), "ID", "Name", emp.CourseId);
            return View(emp);
        }
    }
}
