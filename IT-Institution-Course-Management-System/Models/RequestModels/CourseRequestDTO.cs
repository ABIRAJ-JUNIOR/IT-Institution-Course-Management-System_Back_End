namespace IT_Institution_Course_Management_System.Models.RequestModels
{
    public class CourseRequestDTO
    {
        public string Id { get; set; }
        public string CourseName { get; set; }
        public string Level { get; set; }
        public int TotalFee { get; set; }
    }
}
