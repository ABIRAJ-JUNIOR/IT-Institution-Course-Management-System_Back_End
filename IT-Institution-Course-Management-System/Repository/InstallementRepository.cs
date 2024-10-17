using IT_Institution_Course_Management_System.Entities;
using IT_Institution_Course_Management_System.IRepository;
using IT_Institution_Course_Management_System.Models.ResponseModels;
using Microsoft.Data.Sqlite;

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

            public InstallmentDetail AddInstallment(InstallmentDetail installmentDetail)
            {
                throw new NotImplementedException();
            }

            public ICollection<InstallmentResponseDTO> GetAllInstallments()
            {
                var InstallmentsList = new List<InstallmentResponseDTO>();
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM Installments";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InstallmentsList.Add(new InstallmentResponseDTO()
                            {
                                Id = reader.GetString(0),
                                Nic = reader.GetString(1),
                                TotalAmount = reader.GetDecimal(2),
                                InstallmentAmount = reader.GetDecimal(3),
                                Installments = reader.GetString(4),
                                PaymentDue = reader.GetDecimal(5),
                                PaymentPaid = reader.GetDecimal(6),
                                PaymentDate = reader.GetDateTime(7)
                            });
                        }
                    }
                }
                return InstallmentsList;
            }

            public InstallmentResponseDTO GetInstallmentById(string Id)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM Installments WHERE Id == @id";
                    command.Parameters.AddWithValue("@id", Id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new InstallmentResponseDTO()
                            {
                                Id = reader.GetString(0),
                                Nic = reader.GetString(1),
                                TotalAmount = reader.GetDecimal(2),
                                InstallmentAmount = reader.GetDecimal(3),
                                Installments = reader.GetString(4),
                                PaymentDue = reader.GetDecimal(5),
                                PaymentPaid = reader.GetDecimal(6),
                                PaymentDate = reader.GetDateTime(7)
                            };
                        }
                        else
                        {
                            throw new Exception("Installment Detail Not Found!");
                        }
                    };
                };
                return null;
            }
        }
    }
}
