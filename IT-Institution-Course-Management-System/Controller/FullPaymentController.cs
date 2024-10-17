using IT_Institution_Course_Management_System.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_Institution_Course_Management_System.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FullPaymentController : ControllerBase
    {
        private readonly IFullPaymentRepository _fullPaymentRepository;

        public FullPaymentController(IFullPaymentRepository fullPaymentRepository)
        {
            _fullPaymentRepository = fullPaymentRepository;
        }


        [HttpGet("Get-All-FullPayments")]

        public IActionResult GetAllFullPayments()
        {
            var fullPaymentsList = _fullPaymentRepository.GetAllFullPayments();
            return Ok(fullPaymentsList);
        }
    }
}
