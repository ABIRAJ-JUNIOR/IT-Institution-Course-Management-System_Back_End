namespace IT_Institution_Course_Management_System.Entities
{
    public class CourseEnrollDetail
    {
        public string Id { get; set; }
        public string Nic { get; set; }
        public string CourseId { get; set; }
        public string Duration { get; set; }
        public string? InstallmentId { get; set; }
        public string? FullPaymentId { get; set; }
        public DateTime CourseEnrollDate { get; set; }
        public string Status { get; set; }
    }
}
