using IT_Institution_Course_Management_System.IRepository;
using IT_Institution_Course_Management_System.Models.RequestModels;
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

        [HttpPost("Add-Course-Enroll-Detail")]

        public IActionResult AddEnrollDetails(AddCourseEnrollDTO AddEnrollDto)
        {
            var CourseEnrollDetail = _courseEnrollRepository.AddEnrollDetails(AddEnrollDto);
            return Ok(CourseEnrollDetail);
        }

        [HttpPut("Add-payment-Id/{CourseEnrollId}/{InstallmentId}/{FullPaymentId}")]

        public IActionResult AddPaymentId(string CourseEnrollId, string InstallmentId, string FullPaymentId)
        {
            _courseEnrollRepository.AddPaymentId(CourseEnrollId, InstallmentId, FullPaymentId);
            return Ok("Payment ID Added Successfully.");
        }
    }
}
