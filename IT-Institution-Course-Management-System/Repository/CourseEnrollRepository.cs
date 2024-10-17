using IT_Institution_Course_Management_System.IRepository;
using IT_Institution_Course_Management_System.Models.ResponseModels;
using Microsoft.Data.Sqlite;

namespace IT_Institution_Course_Management_System.Repository
{
    public class CourseEnrollRepository: ICourseEnrollRepository
    {
        private readonly string _connectionString;

        public CourseEnrollRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
      
    }
}
