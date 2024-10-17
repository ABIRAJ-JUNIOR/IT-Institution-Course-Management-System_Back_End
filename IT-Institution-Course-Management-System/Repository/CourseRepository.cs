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
        public CourseResponseDTO GetCourseById(string CourseId)
        {
            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM Courses WHERE Id == @id";
                    command.Parameters.AddWithValue("@id", CourseId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CourseResponseDTO()
                            {
                                Id = reader.GetString(0),
                                CourseName = reader.GetString(1),
                                Level = reader.GetString(2),
                                TotalFee = reader.GetInt32(3)
                            };
                        }
                        else
                        {
                            throw new Exception("Course Not Found!");
                        }
                    };
                };
                return null;
            }
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }
        public CourseResponseDTO AddCourse(CourseResponseDTO courseDto)
        {
            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO Courses (Id,CourseName,Level,TotalFee) VALUES (@id,@courseName,@level,@totalFee);";
                    command.Parameters.AddWithValue("@id", courseDto.Id);
                    command.Parameters.AddWithValue("@courseName", courseDto.CourseName);
                    command.Parameters.AddWithValue("@level", courseDto.Level);
                    command.Parameters.AddWithValue("@totalFee", courseDto.TotalFee);
                    command.ExecuteNonQuery();
                }

                return courseDto;
            }
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }
        public void UpdateCourse(string CourseID, int TotalFee)
        {

            if (TotalFee >= 0)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE Courses SET TotalFee = @totalFee  WHERE Id == @id";
                    command.Parameters.AddWithValue("@id", CourseID);
                    command.Parameters.AddWithValue("@totalFee", TotalFee);
                    var RowEffected = command.ExecuteNonQuery();
                    if (RowEffected <= 0)
                    {
                        throw new Exception("Course NOT Found..");
                    }
                }
            }
            else
            {
                throw new Exception("Fee is shoud be Positive Number.");
            }

        }
        public void DeleteCourse(string CourseId)
        {
            var course = GetCourseById(CourseId);
            if (course != null)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM Courses WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", CourseId);
                    var RowEffected = command.ExecuteNonQuery();
                    if (RowEffected <= 0)
                    {
                        throw new Exception("Course NOT Found..");
                    }
                }
            }
            else
            {
                throw new Exception("Course Not Fount");
            }

        }

    }
}
