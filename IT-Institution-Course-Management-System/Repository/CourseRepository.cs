using IT_Institution_Course_Management_System.IRepository;
using IT_Institution_Course_Management_System.Models.ResponseModels;
using Microsoft.Data.Sqlite;

namespace IT_Institution_Course_Management_System.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly string _connectionString;

        public CourseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ICollection<CourseResponseDTO> GetAllCourses()
        {
            try
            {
                var CourseList = new List<CourseResponseDTO>();
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM Courses";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CourseList.Add(new CourseResponseDTO()
                            {
                                Id = reader.GetString(0),
                                CourseName = reader.GetString(1),
                                Level = reader.GetString(2),
                                TotalFee = reader.GetInt32(3)
                            });
                        }
                    }
                }
                return CourseList;
            }
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }
    }
}
