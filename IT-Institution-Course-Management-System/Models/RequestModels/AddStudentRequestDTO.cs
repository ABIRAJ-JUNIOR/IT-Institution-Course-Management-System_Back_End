namespace IT_Institution_Course_Management_System.Models.RequestModels
{
    public class AddStudentRequestDTO
    {
        public string Nic { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int RegistrationFee { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
