﻿using IT_Institution_Course_Management_System.Entities;
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
            try
            {
                var installmentsList = _installmentRepository.GetAllInstallments();
                return Ok(installmentsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add-installment")]

        public IActionResult AddInstallment(InstallmentDetail installmentDetail)
        {
            try
            {
                var installment = _installmentRepository.AddInstallment(installmentDetail);
                return Ok(installment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update-Installment/{InstallmentId}/{PaidAmount}")]

        public IActionResult UpdateInstallment(string InstallmentId, decimal PaidAmount)
        {
            try
            {
                var installmentDetail = _installmentRepository.UpdateInstallment(InstallmentId, PaidAmount);
                return Ok(installmentDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
