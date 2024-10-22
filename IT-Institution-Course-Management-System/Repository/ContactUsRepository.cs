using IT_Institution_Course_Management_System.Entities;
using IT_Institution_Course_Management_System.IRepository;
using Microsoft.Data.Sqlite;

namespace IT_Institution_Course_Management_System.Repository
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly string _connectionString;

        public ContactUsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ContactUs AddContactUsDetails(ContactUs contactUs)
        {
            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO ContactUS (Id,Name,Email,Message,SubmitDate) VALUES (@id,@name,@email,@message,@submitDate);";
                    command.Parameters.AddWithValue("@id", contactUs.Id);
                    command.Parameters.AddWithValue("@name", contactUs.Name);
                    command.Parameters.AddWithValue("@email", contactUs.Email);
                    command.Parameters.AddWithValue("@message", contactUs.Message);
                    command.Parameters.AddWithValue("@submitDate", contactUs.SubmitDate);
                    command.ExecuteNonQuery();
                }
                return contactUs;
            }
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }
    }
}
