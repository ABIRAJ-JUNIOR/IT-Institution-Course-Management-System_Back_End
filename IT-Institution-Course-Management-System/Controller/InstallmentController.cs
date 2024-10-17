using IT_Institution_Course_Management_System.Entities;
using IT_Institution_Course_Management_System.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_Institution_Course_Management_System.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentController : ControllerBase
    {
        public readonly IInstallmentRepository _installmentRepository;

        public InstallmentController(IInstallmentRepository installmentRepository)
        {
            _installmentRepository = installmentRepository;
        }

        [HttpGet("Get-All-Installments")]

        public IActionResult GetAllInstallments()
        {
            var installmentsList = _installmentRepository.GetAllInstallments();
            return Ok(installmentsList);
        }

        [HttpPost("Add-installment")]

        public IActionResult AddInstallment(InstallmentDetail installmentDetail)
        {
            var installment = _installmentRepository.AddInstallment(installmentDetail);
            return Ok(installment);
        }
    }
}
