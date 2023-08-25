using System;
using System.Collections.Generic;

namespace AssessmentDb.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        
        // Foreign key
        public int UserId { get; set; }

        // Navigation properties
        public User User { get; set; } = null!;
        
        public List<Product> Products { get; set; } = null!;
        
        public Shipment Shipment { get; set; } = null!;
        public Payment Payment { get; set; } = null!;
    }
}
