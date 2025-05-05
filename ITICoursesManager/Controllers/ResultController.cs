using ITICoursesManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITICoursesManager.Controllers
{
    public class ResultController : Controller
    {
        ITIContext context;

        public ResultController(ITIContext context)
        {
            this.context = context;
        }

        public IActionResult Show()
        {
            var results = context.CRResult.ToList();
            var trainees = context.Trainees.ToList();
            var courses = context.Courses.ToList();
            var vms = new List<ResultsFullDetails>();
            foreach (var r in results)
            {
                vms.Add(new ResultsFullDetails(courses.FirstOrDefault(c => c.Id == r.CourseId),
                    trainees.FirstOrDefault(e => e.Id == r.TraineeId), r.Degree));
            }
            return View("Show",vms);
        }

        public IActionResult ShowResult(int crsId, int trId)
        {
            var result = context.CRResult.ToList().FirstOrDefault(r => r.CourseId == crsId && r.TraineeId == trId);
            var trainee = context.Trainees.ToList().FirstOrDefault(t => t.Id == result.TraineeId);
            var crs = context.Courses.ToList().FirstOrDefault(c => c.Id == result.CourseId);
            return View("ShowResult", new ResultsFullDetails(crs, trainee, result.Degree));
        }

        public IActionResult ShowCourseResults(int id)
        {
            var results = context.CRResult.ToList().Where(r => r.CourseId == id);
            var crs = context.Courses.ToList().FirstOrDefault(c => c.Id == id);
            var trainees = context.Trainees.ToList();
            var vms = new List<ResultsFullDetails>();

            foreach (var r in results)
            {
                vms.Add(new ResultsFullDetails(crs, trainees.FirstOrDefault(e => e.Id == r.TraineeId), r.Degree));
            }
            return View("ShowCourseResults", vms);
        }
    }
}
