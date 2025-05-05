using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ITICoursesManager.Models;

public class Trainee
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string ImagURL { get; set; }
    public int Grade { get; set; }

    [ForeignKey("Department")]
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public List<CRResult> CRResult { get; set; }
}
