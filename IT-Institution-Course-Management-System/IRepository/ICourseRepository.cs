using IT_Institution_Course_Management_System.Models.ResponseModels;

namespace IT_Institution_Course_Management_System.IRepository
{
    public interface ICourseRepository
    {
        ICollection<CourseResponseDTO> GetAllCourses();
        CourseResponseDTO GetCourseById(string CourseId);
        CourseResponseDTO AddCourse(CourseResponseDTO courseDto);
        void UpdateCourse(string CourseID, int TotalFee);

    }
}
