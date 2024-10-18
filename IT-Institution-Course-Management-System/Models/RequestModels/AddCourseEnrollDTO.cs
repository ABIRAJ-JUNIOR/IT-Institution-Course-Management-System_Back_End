namespace IT_Institution_Course_Management_System.Models.RequestModels
{
    public class AddCourseEnrollDTO
    {
        public string Id { get; set; }
        public string Nic { get; set; }
        public string CourseId { get; set; }
        public string Duration { get; set; }
        public DateTime CourseEnrollDate { get; set; }
        public string Status { get; set; }
    }
}
