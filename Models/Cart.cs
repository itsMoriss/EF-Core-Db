using System.Collections.Generic;

namespace AssessmentDb.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        
        // Foreign key
        public int UserId { get; set; }

        // Navigation properties
        public User User { get; set; } = null!;
        
        public List<Product> Products { get; set; } = null!;
    }
}
