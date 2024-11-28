namespace FitnessClubManagementAPI.Data
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int MemberId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
