using IT_Institution_Course_Management_System.Models.RequestModels;
using IT_Institution_Course_Management_System.Models.ResponseModels;

namespace IT_Institution_Course_Management_System.IRepository
{
    public interface ICourseRepository
    {
        ICollection<CourseResponseDTO> GetAllCourses();
        CourseResponseDTO GetCourseById(string CourseId);
        CourseResponseDTO AddCourse(CourseRequestDTO courseDto);
        void UpdateCourse(string CourseID, int TotalFee);
        void DeleteCourse(string CourseId);

    }
}
