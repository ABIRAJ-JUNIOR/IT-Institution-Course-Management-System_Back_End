using IT_Institution_Course_Management_System.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_Institution_Course_Management_System.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet("Get-All-Courses")]

        public IActionResult GetAllCourses()
        {
            var CourseList = _courseRepository.GetAllCourses();
            return Ok(CourseList);
        }
        [HttpGet("Get-Course-By-ID /{CourseId}")]

        public IActionResult GetCourseById(string CourseId)
        {
            try
            {
                var Course = _courseRepository.GetCourseById(CourseId);
                return Ok(Course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
