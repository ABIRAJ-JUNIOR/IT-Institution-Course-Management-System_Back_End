using IT_Institution_Course_Management_System.IRepository;

namespace IT_Institution_Course_Management_System.Repository
{
    public class FullPaymentRepository : IFullPaymentRepository
    {
        public readonly string _connectionString;

        public FullPaymentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
