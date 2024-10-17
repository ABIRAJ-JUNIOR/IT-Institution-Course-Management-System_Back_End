using IT_Institution_Course_Management_System.Entities;
using IT_Institution_Course_Management_System.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_Institution_Course_Management_System.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsRepository _contactUsRepository;

        public ContactUsController(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        [HttpPost("Add-ContactUs-Details")]

        public IActionResult AddContactUsDetails(ContactUs contactUs)
        {
            var ContactUsDetails = _contactUsRepository.AddContactUsDetails(contactUs);
            return Ok(ContactUsDetails);
        }
    }
}
