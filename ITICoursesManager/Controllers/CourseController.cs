using ITICoursesManager.Models;
using ITICoursesManager.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ITICoursesManager.Controllers;

public class CourseController : Controller
{
    ITIContext context;
    public CourseController(ITIContext _context)
    {
        context = _context;
    }
    public IActionResult IsUnique(string Name,int Id)
    {
        var crs = context.Courses.ToList().FirstOrDefault(c => c.Id == Id);
        if(crs is not null)
        {
            if (Name == crs.Name)
                return Json(true);
        }
        return context.Courses.ToList().FirstOrDefault(c => c.Name == Name) is null ? Json(true) : Json(false);
    }
 
    public IActionResult ShowAll()
    {
        var crs = context.Courses.ToList();
        return View("ShowAll",crs);
    }

    public IActionResult AddNew()
    {
        var instructors = context.Instructors.ToList();
        var departments = context.Departments.ToList();
        var vm = new CourseDeptInstru(null!, instructors,departments);
        return View("AddNew", vm);
    }

    [ValidateAntiForgeryToken]
    public IActionResult SaveAdded(Course crs)
    {
        if(ModelState.IsValid)
        {
            context.Courses.Add(crs);
            context.SaveChanges();
            return RedirectToAction("ShowAll");
        }
        else
        {
            var instructors = context.Instructors.ToList();
            var departments = context.Departments.ToList();
            var vm = new CourseDeptInstru(crs, instructors, departments);
            return View("AddNew", vm);
        }                
    }
    public IActionResult Edit(int id)
    {
        var instructors = context.Instructors.ToList();
        var departments = context.Departments.ToList();
        var crs = context.Courses.ToList().FirstOrDefault(c => c.Id == id);
        var vm = new CourseDeptInstru(crs, instructors, departments);
        return View("Edit", vm);
    }

    [ValidateAntiForgeryToken]
    public IActionResult SaveEditted(Course crs)
    {
        if (ModelState.IsValid)
        {
            var crsDB = context.Courses.ToList().FirstOrDefault(c => c.Id == crs.Id);
            crsDB.Name = crs.Name;
            crsDB.Hours = crs.Hours;
            crsDB.Degree = crs.Degree;
            crsDB.MinDegree = crs.MinDegree;
            crsDB.DepartmentId = crs.DepartmentId;
            context.SaveChanges();
            return RedirectToAction("ShowAll");
        }
        else
        {
            var instructors = context.Instructors.ToList();
            var departments = context.Departments.ToList();
            var vm = new CourseDeptInstru(crs, instructors, departments);
            return View("Edit", vm);
        }
    }
}
