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
            try
            {
                var courseEnrollData = _courseEnrollRepository.GetAllEnrollData();
                return Ok(courseEnrollData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Add-Course-Enroll-Detail")]

        public IActionResult AddEnrollDetails(AddCourseEnrollDTO AddEnrollDto)
        {
            try
            {
                var CourseEnrollDetail = _courseEnrollRepository.AddEnrollDetails(AddEnrollDto);
                return Ok(CourseEnrollDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Add-payment-Id/{CourseEnrollId}/{InstallmentId}/{FullPaymentId}")]

        public IActionResult AddPaymentId(string CourseEnrollId, string InstallmentId, string FullPaymentId)
        {
            try
            {
                _courseEnrollRepository.AddPaymentId(CourseEnrollId, InstallmentId, FullPaymentId);
                return Ok("Payment ID Added Successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update-Status/{CourseEnrollId}/{Status}")]

        public IActionResult UpdateStatus(string CourseEnrollId, string Status)
        {
            try
            {
                _courseEnrollRepository.UpdateStatus(CourseEnrollId, Status); ;
                return Ok("Status Update Successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
