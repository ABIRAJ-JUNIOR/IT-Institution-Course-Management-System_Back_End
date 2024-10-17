using IT_Institution_Course_Management_System.Entities;
using IT_Institution_Course_Management_System.Models.RequestModels;
using IT_Institution_Course_Management_System.Models.ResponseModels;

namespace IT_Institution_Course_Management_System.IRepository
{
    public interface IStudentRepository
    {
        ICollection<StudentResponseDTO> GetAllStudents();
        StudentResponseDTO GetStudentByNic(string Nic);
        Student AddStudent(Student student);
    }
}
