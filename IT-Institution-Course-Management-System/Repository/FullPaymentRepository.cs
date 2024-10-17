﻿using IT_Institution_Course_Management_System.IRepository;
using IT_Institution_Course_Management_System.Models.ResponseModels;
using Microsoft.Data.Sqlite;

namespace IT_Institution_Course_Management_System.Repository
{
    public class FullPaymentRepository : IFullPaymentRepository
    {
        public readonly string _connectionString;

        public FullPaymentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ICollection<FullPaymentResponseDTO> GetAllFullPayments()
        {
            try
            {
                var FullPaymentList = new List<FullPaymentResponseDTO>();
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM FullPayments";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FullPaymentList.Add(new FullPaymentResponseDTO()
                            {
                                Id = reader.GetString(0),
                                Nic = reader.GetString(1),
                                FullPayment = reader.GetInt32(2),
                                PaymentDate = reader.GetDateTime(3),
                            });
                        }
                    }
                }
                return FullPaymentList;
            }
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }
    }
}
