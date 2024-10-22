using IT_Institution_Course_Management_System.IRepository;
using IT_Institution_Course_Management_System.Models.RequestModels;
using IT_Institution_Course_Management_System.Models.ResponseModels;
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
            try
            {
                var fullPaymentsList = _fullPaymentRepository.GetAllFullPayments();
                return Ok(fullPaymentsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add-FullPayment")]

        public IActionResult AddFullPayment(FullPaymentRequestDTO fullPaymentDto)
        {
            try
            {
                var fullPaymentDetail = _fullPaymentRepository.AddFullPayment(fullPaymentDto);
                return Ok(fullPaymentDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
