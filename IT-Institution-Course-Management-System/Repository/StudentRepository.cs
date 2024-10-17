using IT_Institution_Course_Management_System.IRepository;
using IT_Institution_Course_Management_System.Models.ResponseModels;
using Microsoft.Data.Sqlite;

namespace IT_Institution_Course_Management_System.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ICollection<StudentResponseDTO> GetAllStudents()
        {
            var studentsList = new List<StudentResponseDTO>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Students";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        studentsList.Add(new StudentResponseDTO()
                        {
                            Nic = reader.GetString(0),
                            FullName = reader.GetString(1),
                            Email = reader.GetString(2),
                            Phone = reader.GetString(3),
                            Password = reader.GetString(4),
                            RegistrationFee = reader.GetInt32(5),
                            CourseEnrollId = reader.IsDBNull(6) ? null : reader.GetString(6),
                            ImagePath = reader.GetString(7) == "" ? "/profileimages/ebd29e7b-020f-4791-97a8-22d17d6e255c.jpeg" : reader.GetString(7),

                        });
                    }
                }
            }
            return studentsList;
        }


        public StudentResponseDTO GetStudentByNic(string Nic)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Students WHERE Nic == @nic";
                command.Parameters.AddWithValue("@nic", Nic);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new StudentResponseDTO()
                        {
                            Nic = reader.GetString(0),
                            FullName = reader.GetString(1),
                            Email = reader.GetString(2),
                            Phone = reader.GetString(3),
                            Password = reader.GetString(4),
                            RegistrationFee = reader.GetInt32(5),
                            CourseEnrollId = reader.IsDBNull(6) ? null : reader.GetString(6),
                            ImagePath = reader.GetString(7) == "" ? "/profileimages/ebd29e7b-020f-4791-97a8-22d17d6e255c.jpeg" : reader.GetString(7),
                        };
                    }
                    else
                    {
                        throw new Exception("Student Not Found!");
                    }
                };
            };
            return null;
        }
    }
}
