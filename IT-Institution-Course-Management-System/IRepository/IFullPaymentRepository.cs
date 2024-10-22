using IT_Institution_Course_Management_System.Models.RequestModels;
using IT_Institution_Course_Management_System.Models.ResponseModels;

namespace IT_Institution_Course_Management_System.IRepository
{
    public interface IFullPaymentRepository
    {
        ICollection<FullPaymentResponseDTO> GetAllFullPayments();
        FullPaymentResponseDTO AddFullPayment(FullPaymentRequestDTO fullPaymentDto);

    }
}
