using System.ComponentModel.DataAnnotations;

namespace ITICoursesManager.Models;

public class Department
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string ManagerName { get; set; }
    public List<Course> Courses { get; set; }
    public List<Instructor> Instructors { get; set; }
    public List<Trainee> Trainees { get; set; }
}
