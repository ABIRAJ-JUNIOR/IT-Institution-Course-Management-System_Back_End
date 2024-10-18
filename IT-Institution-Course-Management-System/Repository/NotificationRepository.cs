using IT_Institution_Course_Management_System.IRepository;
using IT_Institution_Course_Management_System.Models.RequestModels;
using IT_Institution_Course_Management_System.Models.ResponseModels;
using Microsoft.Data.Sqlite;

namespace IT_Institution_Course_Management_System.Repository
{
    public class NotificationRepository: INotificationRepository
    {
        private readonly string _ConnectionString;

        public NotificationRepository(string connectionString)
        {
            _ConnectionString = connectionString;
        }
        public ICollection<NotificationResponseDTO> GetAllNotifications()
        {
            try
            {
                var notificationList = new List<NotificationResponseDTO>();
                using (var connection = new SqliteConnection(_ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"SELECT * FROM Notifications";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var notification = new NotificationResponseDTO()
                            {
                                Id = reader.GetInt32(0),
                                Nic = reader.GetString(1),
                                Type = reader.GetString(2),
                                SourceId = reader.GetString(3),
                                Date = reader.GetDateTime(4),
                                IsDeleted = reader.GetBoolean(5)
                            };
                            notificationList.Add(notification);
                        }
                    }
                }
                return notificationList;
            }
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }
        public void AddNotification(NotificationRequestDTO notification)
        {
            try
            {
                using (var connection = new SqliteConnection(_ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"INSERT INTO Notifications(Nic,Type,SourceId,Date,IsDeleted) Values (@nic,@type,@sourceId,@date,@isDeleted)";
                    command.Parameters.AddWithValue("@nic", notification.Nic);
                    command.Parameters.AddWithValue("@type", notification.Type);
                    command.Parameters.AddWithValue("@sourceId", notification.SourceId);
                    command.Parameters.AddWithValue("@date", notification.Date);
                    command.Parameters.AddWithValue("@isDeleted", false);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }
        public void DeleteNotification(int id)
        {
            try
            {
                using (var connection = new SqliteConnection(_ConnectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"UPDATE Notifications SET IsDeleted = @isDeleted WHERE Id == @id";
                    command.Parameters.AddWithValue("@isDeleted", true);
                    command.Parameters.AddWithValue("@id", id);
                    var RowEffected = command.ExecuteNonQuery();
                    if (RowEffected <= 0)
                    {
                        throw new Exception("Notification Not Found..");
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception($"Error: {error.Message}");
            }
        }

    }
}
