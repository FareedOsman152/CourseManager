using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITICoursesManager.Models;

public class Course
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    [Remote(action:"CheckName",controller:"Course", ErrorMessage ="The Name Must Have ITI")]
    public string Name { get; set; }
    [Required]
    [Range(4,13)]
    public int Hours { get; set; }
    [Range(50, 100)]

    public int Degree { get; set; }
    public int MinDegree { get; set; }

    [ForeignKey("Department")]
    public int DepartmentId { get; set; }
    [ValidateNever]
    public Department Department { get; set; }
    [ValidateNever]
    public List<Instructor> Instructors { get; set; }
    [ValidateNever]
    public List<CRResult> CRResult { get; set; }
}
