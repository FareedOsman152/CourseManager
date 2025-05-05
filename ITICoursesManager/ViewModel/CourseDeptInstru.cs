using ITICoursesManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ITICoursesManager.ViewModel
{
    public class CourseDeptInstru
    {
        public int Id { get; set; }
        [Required]
        [Remote(action: "IsUnique", controller: "Course", ErrorMessage = "The Name Must Be Unique"
            ,AdditionalFields ="Id")]
        public string Name { get; set; }
        [Required]
        [Range(4, 13)]
        public int Hours { get; set; }
        [Range(50, 100)]

        public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int DepartmentId { get; set; }
        [ValidateNever]
        public List<Instructor> Instructors { get; set; }
        [ValidateNever]
        public List<Department> Departments { get; set; }
        public CourseDeptInstru(Course course , List<Instructor> instructors, List<Department> departments)
        {
            if (course is not null)
            {
                Id = course.Id;
                Name = course.Name;
                Hours = course.Hours;
                Degree = course.Degree;
                MinDegree = course.MinDegree;
                DepartmentId = course.DepartmentId;
            }
            Instructors = instructors;
            Departments = departments;
        }
        public CourseDeptInstru()
        {
            
        }
    }
}
