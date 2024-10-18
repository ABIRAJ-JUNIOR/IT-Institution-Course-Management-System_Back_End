namespace IT_Institution_Course_Management_System.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Nic { get; set; }
        public string Type { get; set; }
        public string SourceId { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}
