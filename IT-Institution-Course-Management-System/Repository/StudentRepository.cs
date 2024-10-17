using IT_Institution_Course_Management_System.IRepository;

namespace IT_Institution_Course_Management_System.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
