namespace IT_Institution_Course_Management_System.Models.RequestModels
{
    public class NotificationRequestDTO
    {
        public string Nic { get; set; }
        public string Type { get; set; }
        public string SourceId { get; set; }
        public DateTime Date { get; set; }
    }
}
