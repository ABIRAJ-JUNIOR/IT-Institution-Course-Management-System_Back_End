namespace IT_Institution_Course_Management_System.Models.RequestModels
{
    public class ProfilePictureRequestDTO
    {
        public string Nic { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
