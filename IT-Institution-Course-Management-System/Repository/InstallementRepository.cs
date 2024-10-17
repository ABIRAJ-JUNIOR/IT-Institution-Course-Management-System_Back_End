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

            public InstallmentDetail AddInstallment(InstallmentDetail installmentDetail)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO Installments (Id,Nic,TotalAmount,InstallmentAmount,Installments,PaymentDue,PaymentPaid,PaymentDate) VALUES (@Id,@nic,@totalAmount,@InstallmentAmount,@installments,@paymentDue,@paymentPaid,@paymentDate);";
                    command.Parameters.AddWithValue("@Id", installmentDetail.Id);
                    command.Parameters.AddWithValue("@nic", installmentDetail.Nic);
                    command.Parameters.AddWithValue("@totalAmount", installmentDetail.TotalAmount);
                    command.Parameters.AddWithValue("@InstallmentAmount", installmentDetail.InstallmentAmount);
                    command.Parameters.AddWithValue("@installments", installmentDetail.Installments);
                    command.Parameters.AddWithValue("@paymentDue", installmentDetail.PaymentDue);
                    command.Parameters.AddWithValue("@paymentPaid", installmentDetail.PaymentPaid);
                    command.Parameters.AddWithValue("@paymentDate", installmentDetail.PaymentDate);
                    command.ExecuteNonQuery();
                }

                return installmentDetail;
            }

            public InstallmentResponseDTO UpdateInstallment(string InstallmentId, decimal PaidAmount)
            {
                var installmentDetail = GetInstallmentById(InstallmentId);
                decimal PaymentPaid = installmentDetail.PaymentPaid + PaidAmount;
                decimal PaymentDue = installmentDetail.PaymentDue - PaidAmount;

                DateTime today = DateTime.Now;
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE Installments SET PaymentDue = @paymentDue , PaymentPaid = @paymentPaid , PaymentDate = @paymentDate WHERE Id == @id";
                    command.Parameters.AddWithValue("@paymentDue", PaymentDue);
                    command.Parameters.AddWithValue("@paymentPaid", PaymentPaid);
                    command.Parameters.AddWithValue("@paymentDate", today);
                    command.Parameters.AddWithValue("@id", InstallmentId);
                    command.ExecuteNonQuery();
                }

                var UpdatedInstallmentDetail = GetInstallmentById(InstallmentId);

                return UpdatedInstallmentDetail;
            }
        }
    }
}
