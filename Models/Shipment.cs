namespace AssessmentDb.Models
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public DateTime ShipmentDate { get; set; }
        
        // Foreign key
        public int OrderId { get; set; }

        // Navigation property
        public Order Order { get; set; } = null!;
    }
}
