namespace AssessmentDb.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }

        // Foreign key
        public int? OrderId { get; set; }

        // Navigation property
        public Order Order { get; set; } = null!;
    }
}
