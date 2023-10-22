using CRECT2.Interface;
using CRECT2.Models;
using CRECT2.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRECT2.Controllers
{
    
    public class DepartmentController : Controller
    {
        public G_Interface<Employee> Empinterface { get; set; }
        public G_Interface<Department> Deptinterface { get; set; }
        public G_Interface<Course> Crsinterface {  get; set; }
        public  VM_Interface_<Emp_For_Dept> VMdept { get; set; }

        public DepartmentController(G_Interface<Employee> _Empinterface, G_Interface<Department> _Deptinterface, VM_Interface_<Emp_For_Dept> _VMdept, G_Interface<Course> _Crsinterface)
        {
            Empinterface= _Empinterface;
            Deptinterface= _Deptinterface;
            Crsinterface= _Crsinterface;
            VMdept= _VMdept;
        }
        [Authorize]
        public IActionResult ShowAll()
        {

            IEnumerable<Emp_For_Dept> x = VMdept.EmpDept();
            return View(x);
        }
        [HttpGet]
       
        public IActionResult AddItem()
        {
            //var x = new SelectList(Empinterface.GetAll(), nameof(Department.ID), nameof(Department.Name));
            //ViewBag.ListDept = x;

            //var y = new SelectList(Crsinterface.GetAll(), nameof(Course.ID), nameof(Course.Name));
            //ViewBag.ListCrs = y;



            return View(new Department());

        }
        [HttpPost]
      
        public IActionResult AddItem(Department Dept)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData["ADD"] = Dept.Name;
                    Deptinterface.Create(Dept);
                    return RedirectToAction("ShowAll");
                }
                catch (Exception ex)
                {
                    


                    ModelState.AddModelError("Database", "error in data " + ModelState);
                    return View(Dept);
                }
            }
            ModelState.AddModelError("Database", "error in data " + ModelState);
            return View(Dept);

        }
        [HttpGet]
     
        public IActionResult UpdateItem(int id)
        {
            var Dept = Deptinterface.GetById(id);
           
            ModelState.AddModelError("Database", "error in data " + ModelState);
            return View(Dept);
        }
        [HttpPost]
       
        public IActionResult UpdateItem(Department Dept)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Edite"] = Dept.Name;
                    Deptinterface.Edite(Dept, Dept.ID);
                    return RedirectToAction("ShowAll");

                }
                catch (Exception ex)
                {
                    
                   

                    ModelState.AddModelError("Database", "error in data " + ModelState);
                   

                }
              
              

                ModelState.AddModelError("Database", "error in data " + ModelState);
                return View(Dept);

            }
            
           

            ModelState.AddModelError("Database", "error in data " + ModelState);
            return View(Dept);
        }
        public IActionResult DeleteItem(int id)
        {
            var x = Deptinterface.GetById(id);
            TempData["Delete"] = x.Name;
            Deptinterface.Delete(id);
            return RedirectToAction("ShowAll");
        }
      
    }
}

    

