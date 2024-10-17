using IT_Institution_Course_Management_System.Entities;
using IT_Institution_Course_Management_System.IRepository;
using IT_Institution_Course_Management_System.Models.RequestModels;
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

        [HttpPost("Add-student")]
        public async Task<IActionResult> AddStudent(AddStudentRequestDTO addStudent)
        {
            var StudentObj = new Student()
            {
                Nic = addStudent.Nic,
                FullName = addStudent.FullName,
                Email = addStudent.Email,
                Phone = addStudent.Phone,
                Password = addStudent.Password,
                RegistrationFee = addStudent.RegistrationFee,
                CourseEnrollId = null
            };

            if (addStudent.ImageFile != null && addStudent.ImageFile.Length > 0)
            {

                if (string.IsNullOrEmpty(_webHostEnvironment.WebRootPath))
                {
                    throw new ArgumentNullException(nameof(_webHostEnvironment.WebRootPath), "WebRootPath is not set. Make sure the environment is configured properly.");
                }

                var profileimagesPath = Path.Combine(_webHostEnvironment.WebRootPath, "profileimages");


                if (!Directory.Exists(profileimagesPath))
                {
                    Directory.CreateDirectory(profileimagesPath);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(addStudent.ImageFile.FileName);
                var imagePath = Path.Combine(profileimagesPath, fileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await addStudent.ImageFile.CopyToAsync(stream);
                }


                StudentObj.ImagePath = "/profileimages/" + fileName;
            }
            else
            {
                StudentObj.ImagePath = null;
            }


            var studentData = _studentRepository.AddStudent(StudentObj);
            return Ok(studentData);
        }

        [HttpPut("Update-Student/{Nic}")]

        public IActionResult UpdateStudent(string Nic, StudentUpdateRequestDTO studentUpdate)
        {
            try
            {
                _studentRepository.UpdateStudent(Nic, studentUpdate);
                return Ok(studentUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("Update-CourseEnroll-Id/{Nic}/{CourseEnrollId}")]

        public IActionResult AddCourseEnrollId(string Nic, string CourseEnrollId)
        {
            try
            {
                _studentRepository.AddCourseEnrollId(Nic, CourseEnrollId);
                return Ok("CourseEnroll Id Updated Successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Password-Change/{Nic}")]

        public IActionResult PasswordUpdate(string Nic, PasswordUpdateRequestDTO newPassword)
        {
            try
            {
                _studentRepository.PasswordUpdate(Nic, newPassword);
                return Ok("Password Changed Successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
