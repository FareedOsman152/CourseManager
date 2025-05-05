using ITICoursesManager.Models;

namespace ITICoursesManager.ViewModel;

public class InstructorDeptsCrses
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal Salary { get; set; }
    public string ImagURL { get; set; }
    public int DepartmentId { get; set; }
    public List<Department> Depts { get; set; }
    public int CourseId { get; set; }
    public List<Course> Crses { get; set; }
    public InstructorDeptsCrses(Instructor? instructor , List<Department> depts, List<Course>crses)
    {
        if(instructor is not null)
        {
            Id = instructor.Id;
            Name = instructor.Name;
            Address = instructor.Address;
            Salary = instructor.Salary;
            ImagURL = instructor.ImagURL;
            DepartmentId = instructor.DepartmentId;
            CourseId = instructor.CourseId;
        }

        Depts = depts;
        Crses = crses;
    }
}
