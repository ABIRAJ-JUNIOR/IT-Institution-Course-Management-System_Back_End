using IT_Institution_Course_Management_System.Entities;
using IT_Institution_Course_Management_System.Models.ResponseModels;

namespace IT_Institution_Course_Management_System.IRepository
{
    public interface IInstallmentRepository
    {
        ICollection<InstallmentResponseDTO> GetAllInstallments();
        InstallmentDetail AddInstallment(InstallmentDetail installmentDetail);
        InstallmentResponseDTO UpdateInstallment(string InstallmentId, decimal PaidAmount);

    }
}
