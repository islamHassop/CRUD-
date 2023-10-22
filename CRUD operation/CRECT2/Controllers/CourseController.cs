using CRECT2.Interface;
using CRECT2.Models;
using CRECT2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRECT2.Controllers
{
    public class CourseController : Controller
    {
        public G_Interface<Employee> Empinterface { get; set; }
        public G_Interface<Department> Deptinterface { get; set; }
        public G_Interface<Course> Crsinterface { get; set; }
        public VM_Interface_<Emp_For_Dept> VMdept { get; set; }
        public VMCours_Interface<Course_For_Emp> VMCours_Interface { get; set; }
        public CourseController(VMCours_Interface<Course_For_Emp> _VMCours_Interface, G_Interface<Employee> _Empinterface, G_Interface<Department> _Deptinterface, VM_Interface_<Emp_For_Dept> _VMdept, G_Interface<Course> _Crsinterface)
        {
            Empinterface = _Empinterface;
            Deptinterface = _Deptinterface;
            Crsinterface = _Crsinterface;
            VMdept = _VMdept;
            VMCours_Interface = _VMCours_Interface;
        }

        public IActionResult ShowAll()
        {

            var x = VMCours_Interface.Cours_Emp();
            return View(x);
        }
        [HttpGet]
        public IActionResult AddItem()
        {
            var x = new SelectList(Crsinterface.GetAll(), nameof(Department.ID), nameof(Department.Name));
            ViewBag.ListDept = x;

            //var y = new SelectList(Crsinterface.GetAll(), nameof(Course.ID), nameof(Course.Name));
            //ViewBag.ListCrs = y;



            return View(new Course());

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddItem(Course course)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData["ADD"] = course.Name;
                    Crsinterface.Create(course);
                    return RedirectToAction("ShowAll");
                }
                catch (Exception ex)
                {



                    ModelState.AddModelError("Database", "error in data " + ModelState);
                    return View(course);
                }
            }
            ModelState.AddModelError("Database", "error in data " + ModelState);
            return View(course);

        }
        [HttpGet]
        public IActionResult UpdateItem(int id)
        {
            var course = Crsinterface.GetById(id);
            var x = new SelectList(Crsinterface.GetAll(), nameof(Department.ID), nameof(Department.Name));
            ViewBag.ListDept = x;

            return View(course);
        }
        [HttpPost]
        public IActionResult UpdateItem(Course course)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Edite"] = course.Name;
                    Crsinterface.Edite(course, course.ID);
                    return RedirectToAction("ShowAll");

                }
                catch (Exception ex)
                {



                    ModelState.AddModelError("Database", "error in data " + ModelState);


                }



                ModelState.AddModelError("Database", "error in data " + ModelState);
                return View(course);

            }



            ModelState.AddModelError("Database", "error in data " + ModelState);
            return View(course);
        }
        public IActionResult DeleteItem(int id)
        {
            var x = Crsinterface.GetById(id);
            TempData["Delete"] = x.Name;
            Crsinterface.Delete(id);
            return RedirectToAction("ShowAll");
        }
    }

} 
