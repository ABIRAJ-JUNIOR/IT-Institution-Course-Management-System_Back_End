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
        public ICollection<CourseEnrollResponseDTO> GetAllEnrollData()
        {
            var CourseEnrollList = new List<CourseEnrollResponseDTO>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM CourseEnrollDetails";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CourseEnrollList.Add(new CourseEnrollResponseDTO()
                        {
                            Id = reader.GetString(0),
                            Nic = reader.GetString(1),
                            CourseId = reader.GetString(2),
                            Duration = reader.GetString(3),
                            InstallmentId = reader.IsDBNull(4) ? null : reader.GetString(4),
                            FullPaymentId = reader.IsDBNull(5) ? null : reader.GetString(5),
                            CourseEnrollDate = reader.GetDateTime(6),
                            Status = reader.GetString(7)
                        });
                    }
                }
            }
            return CourseEnrollList;
        }

    }
}
