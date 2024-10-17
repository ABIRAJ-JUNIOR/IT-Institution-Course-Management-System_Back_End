using IT_Institution_Course_Management_System.IRepository;

namespace IT_Institution_Course_Management_System.Repository
{
    public class InstallementRepository
    {
        public class InstallmentRepository : IInstallmentRepository
        {
            private readonly string _connectionString;

            public InstallmentRepository(string connectionString)
            {
                _connectionString = connectionString;
            }
        }
}
