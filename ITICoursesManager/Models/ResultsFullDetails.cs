using System.ComponentModel.DataAnnotations;

namespace ITICoursesManager.Models
{
    public class ResultsFullDetails
    {
        public string CourseName { get; set; }
        public int CourseDegree { get; set; }
        public int CourseMinDegree { get; set; }
        public string TraineeName { get; set; }
        public decimal TraineeDegree { get; set; }
        public string color { get; set; }
        public bool Pass { get; set; }
        public ResultsFullDetails(Course crs, Trainee trainee, decimal degree)
        {
            CourseName = crs.Name;
            CourseDegree = crs.Degree;
            CourseMinDegree = crs.MinDegree;
            TraineeName = trainee.Name;
            TraineeDegree = degree;
            Pass = TraineeDegree >= CourseMinDegree;
            color = Pass ? "Green" : "Red";
        }
    }
}
