using IT_Institution_Course_Management_System.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_Institution_Course_Management_System.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudentController(IStudentRepository studentRepository, IWebHostEnvironment webHostEnvironment)
        {
            _studentRepository = studentRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("Get-All-Students")]

        public IActionResult GetAllStudents()
        {
            var StudentsList = _studentRepository.GetAllStudents();
            return Ok(StudentsList);
        }

        [HttpGet("Get-Student-By-Nic /{Nic}")]

        public IActionResult GetStudentByNic(string Nic)
        {
            try
            {
                var Student = _studentRepository.GetStudentByNic(Nic);
                return Ok(Student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
