using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITICoursesManager.Models;

public class CRResult
{
    [Key]
    public int Id { get; set; }
    public decimal Degree { get; set; }
    [ForeignKey("Trainee")]
    public int TraineeId { get; set; }
    public Trainee Trainee { get; set; }
    [ForeignKey("Course")]
    public int CourseId { get; set; }
    public Course Course { get; set; }
}
