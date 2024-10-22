using IT_Institution_Course_Management_System.IRepository;
using IT_Institution_Course_Management_System.Models.RequestModels;
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
            try
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
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }
        public CourseEnrollResponseDTO AddEnrollDetails(AddCourseEnrollDTO AddEnrollDto)
        {
            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO CourseEnrollDetails (Id,Nic,CourseId,Duration,CourseEnrollDate,Status) VALUES (@id,@nic,@courseId,@duration,@courseEnrollDate,@status);";
                    command.Parameters.AddWithValue("@id", AddEnrollDto.Id);
                    command.Parameters.AddWithValue("@nic", AddEnrollDto.Nic);
                    command.Parameters.AddWithValue("@courseId", AddEnrollDto.CourseId);
                    command.Parameters.AddWithValue("@duration", AddEnrollDto.Duration);
                    command.Parameters.AddWithValue("@courseEnrollDate", AddEnrollDto.CourseEnrollDate);
                    command.Parameters.AddWithValue("@status", AddEnrollDto.Status);
                    command.ExecuteNonQuery();
                }

                var CourseEnrollObj = new CourseEnrollResponseDTO()
                {
                    Id = AddEnrollDto.Id,
                    Nic = AddEnrollDto.Nic,
                    CourseId = AddEnrollDto.CourseId,
                    Duration = AddEnrollDto.Duration,
                    InstallmentId = null,
                    FullPaymentId = null,
                    CourseEnrollDate = AddEnrollDto.CourseEnrollDate,
                    Status = AddEnrollDto.Status
                };

                return CourseEnrollObj;
            }
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }
        public void AddPaymentId(string CourseEnrollId, string InstallmentId, string FullPaymentId)
        {
            try
            {
                if (InstallmentId != null && FullPaymentId == "null")
                {
                    using (var connection = new SqliteConnection(_connectionString))
                    {
                        connection.Open();
                        var command = connection.CreateCommand();
                        command.CommandText = "UPDATE CourseEnrollDetails SET InstallmentId = @installmentId WHERE Id = @courseEnrollId";
                        command.Parameters.AddWithValue("@installmentId", InstallmentId);
                        command.Parameters.AddWithValue("@courseEnrollId", CourseEnrollId);
                        command.ExecuteNonQuery();
                    }
                }
                else if (InstallmentId == "null" && FullPaymentId != null)
                {
                    using (var connection = new SqliteConnection(_connectionString))
                    {
                        connection.Open();
                        var command = connection.CreateCommand();
                        command.CommandText = "UPDATE CourseEnrollDetails SET FullPaymentId = @fullPaymentId WHERE Id = @courseEnrollId";
                        command.Parameters.AddWithValue("@fullPaymentId", FullPaymentId);
                        command.Parameters.AddWithValue("@courseEnrollId", CourseEnrollId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }
        public void UpdateStatus(string CourseEnrollId, string Status)
        {
            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE CourseEnrollDetails SET Status = @status WHERE Id = @courseEnrollId";
                    command.Parameters.AddWithValue("@status", Status);
                    command.Parameters.AddWithValue("@courseEnrollId", CourseEnrollId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }


    }
}
