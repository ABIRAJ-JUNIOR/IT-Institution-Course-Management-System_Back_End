namespace IT_Institution_Course_Management_System.Models.ResponseModels
{
    public class FullPaymentResponseDTO
    {
        public string Id { get; set; }
        public string Nic { get; set; }
        public int FullPayment { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
