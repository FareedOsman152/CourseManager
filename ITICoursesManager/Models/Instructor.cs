using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITICoursesManager.Models;

public class Instructor
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Length(3,25)]
    public string Name { get; set; }
    [Required]
    [Length(3, 25)]
    public string Address { get; set; }
    [Required]
    [Range(3, 25)]
    public decimal Salary { get; set; }
    [RegularExpression(@"\w\.(jpg|pnj)")]
    public string ImagURL { get; set; }

    [ForeignKey("Department")]
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }

    [ForeignKey("Course")]
    public int CourseId { get; set; }
    public Course? Course { get; set; }
}
