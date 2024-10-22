using IT_Institution_Course_Management_System.Entities;
using IT_Institution_Course_Management_System.IRepository;
using IT_Institution_Course_Management_System.Models.RequestModels;
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
            try
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
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }

        public Student AddStudent(Student student)
        {
            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO Students (Nic , FullName , Email , Phone , Password , RegistrationFee , ImagePath ) VALUES (@nic,@name,@email,@phone,@password,@registerFee,@imagePath);";
                    command.Parameters.AddWithValue("@nic", student.Nic);
                    command.Parameters.AddWithValue("@name", student.FullName);
                    command.Parameters.AddWithValue("@email", student.Email);
                    command.Parameters.AddWithValue("@phone", student.Phone);
                    command.Parameters.AddWithValue("@password", student.Password);
                    command.Parameters.AddWithValue("@registerFee", student.RegistrationFee);
                    command.Parameters.AddWithValue("@imagePath", student.ImagePath == null ? "" : student.ImagePath);
                    command.ExecuteNonQuery();
                }

                return student;
            }
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }

        public StudentUpdateRequestDTO UpdateStudent(string Nic, StudentUpdateRequestDTO studentUpdate)
        {
            var student = GetStudentByNic(Nic);
            if (student != null)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE Students SET FullName = @name , Email = @email , Phone = @phone  WHERE Nic = @nic";
                    command.Parameters.AddWithValue("@name", studentUpdate.FullName);
                    command.Parameters.AddWithValue("@email", studentUpdate.Email);
                    command.Parameters.AddWithValue("@phone", studentUpdate.Phone);
                    command.Parameters.AddWithValue("@nic", Nic);
                    command.ExecuteNonQuery();
                    return studentUpdate;
                }
            }
            else
            {
                throw new Exception("Stusent Not Found!");
            }

        }

        public void AddCourseEnrollId(string Nic, string CourseEnrollId)
        {
            var student = GetStudentByNic(Nic);
            if (student != null)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE Students SET CourseEnrollId = @courseEnrollId  WHERE Nic = @nic";
                    command.Parameters.AddWithValue("@courseEnrollId", CourseEnrollId);
                    command.Parameters.AddWithValue("@nic", Nic);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                throw new Exception("Stusent Not Found!");
            }
        }

        public void PasswordUpdate(string Nic, PasswordUpdateRequestDTO newPassword)
        {
            var student = GetStudentByNic(Nic);
            if (student != null)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE Students SET Password = @newPassword  WHERE Nic = @nic";
                    command.Parameters.AddWithValue("@newPassword", newPassword.NewPassword);
                    command.Parameters.AddWithValue("@nic", Nic);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                throw new Exception("Student Not Found!");
            }

        }

        public void DeleteStudent(string Nic)
        {
            var student = GetStudentByNic(Nic);
            if (student != null)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM Students WHERE Nic = @nic";
                    command.Parameters.AddWithValue("@nic", Nic);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                throw new Exception("Student Not Found!");
            }

        }

        public void UpdateProfilePic(string Nic, string ImagePath)
        {
            var student = GetStudentByNic(Nic);
            if (student != null)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE Students SET ImagePath = @imagepath  WHERE Nic = @nic";
                    command.Parameters.AddWithValue("@imagepath", ImagePath == null ? "" : ImagePath);
                    command.Parameters.AddWithValue("@nic", Nic);
                    var RowEffected = command.ExecuteNonQuery();
                    if (RowEffected <= 0)
                    {
                        throw new Exception("Student Not Found..");
                    }
                }
            }
            else
            {
                throw new Exception("Student Not Found!");
            }
        }


    }
}
