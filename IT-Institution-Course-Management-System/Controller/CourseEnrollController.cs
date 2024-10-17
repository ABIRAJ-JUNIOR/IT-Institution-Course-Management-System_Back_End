using IT_Institution_Course_Management_System.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_Institution_Course_Management_System.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseEnrollController : ControllerBase
    {
        private readonly ICourseEnrollRepository _courseEnrollRepository;
        public CourseEnrollController(ICourseEnrollRepository courseEnrollRepository)
        {
            _courseEnrollRepository = courseEnrollRepository;
        }

        [HttpGet("Get-All-Enroll-Data")]

        public IActionResult GetAllEnrollData()
        {
            var courseEnrollData = _courseEnrollRepository.GetAllEnrollData();
            return Ok(courseEnrollData);

        }
    }
}
