using ITICoursesManager.Models;
using ITICoursesManager.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITICoursesManager.Controllers;

public class InstructorController : Controller
{
    ITIContext context;

    public InstructorController(ITIContext context)
    {
        this.context = context;
    }

    [Authorize]
    public IActionResult ShowAll()
    {
        var instructors = context.Instructors.ToList();

        return View("ShowAllInstructors",instructors);
    }
    public IActionResult Details(int id)
    {
        var instructor = context.Instructors.ToList().FirstOrDefault(i=>i.Id==id);

        return View("ShowDetails", instructor);
    }

    [HttpGet]
    public IActionResult AddNew()
    {
        var depts = context.Departments.ToList();
        var crses = context.Courses.ToList();
        var instructorViewModel = new InstructorDeptsCrses(null,depts,crses);
        return View("AddNewInstructor",instructorViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SaveNew(Instructor instructor)
    {
        if(ModelState.IsValid)
        {
            context.Instructors.Add(instructor);
            context.SaveChanges();
            return RedirectToAction("ShowAll");
        }
        else
        {
            var depts = context.Departments.ToList();
            var crses = context.Courses.ToList();
            var instructorViewModel = new InstructorDeptsCrses(instructor, depts, crses);
            return View("AddNewInstructor", instructorViewModel);
        }            
    }

    public IActionResult Edit(int id)
    {
        var instructor = context.Instructors.ToList().
            FirstOrDefault(i => i.Id == id);
        var depts = context.Departments.ToList();
        var crses = context.Courses.ToList();
        var instructorViewModel = new InstructorDeptsCrses(instructor, depts, crses);
        return View("EditInstructor", instructorViewModel);
    }

    [RequireHttps]
    [ValidateAntiForgeryToken]
    public IActionResult SaveEdit(Instructor instructor)
    {
        if (ModelState.IsValid)
        {
            var instructorFromDb = context.Instructors.ToList()
                .FirstOrDefault(e => e.Id == instructor.Id);

            instructorFromDb.Id = instructor.Id;
            instructorFromDb.Name = instructor.Name;
            instructorFromDb.Address = instructor.Address;
            instructorFromDb.Salary = instructor.Salary;
            instructorFromDb.ImagURL = instructor.ImagURL;
            instructorFromDb.DepartmentId = instructor.DepartmentId;
            instructorFromDb.CourseId = instructor.CourseId;
            context.SaveChanges();

            return RedirectToAction("ShowAll");
        }
        else
        {
            var depts = context.Departments.ToList();
            var crses = context.Courses.ToList();
            var instructorViewModel = new InstructorDeptsCrses(instructor, depts, crses);
            return View("EditInstructor", instructorViewModel);
        }

    }
    public IActionResult Search(string name)
    {
        return View("Search",name);
    }

    public IActionResult SearchResult(string name)
    {
        var instructor = context.Instructors.ToList()
            .FirstOrDefault(e => e.Name.ToUpper() == name.ToUpper());
        if (instructor is not null)
        {
            return View("ShowDetails", instructor);
        }
        else return RedirectToAction("Search", new {name}); 
    }
}
