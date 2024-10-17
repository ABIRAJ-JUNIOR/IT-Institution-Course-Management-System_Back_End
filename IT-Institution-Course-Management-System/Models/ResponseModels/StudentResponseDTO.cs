namespace IT_Institution_Course_Management_System.Models.ResponseModels
{
    public class StudentResponseDTO
    {
        public string Nic { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int RegistrationFee { get; set; }
        public string CourseEnrollId { get; set; }
        public string ImagePath { get; set; }
    }
}
