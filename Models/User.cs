using System.Collections.Generic;

namespace AssessmentDb.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        
        // Navigation properties
        public List<Order> Orders { get; set; } = null!;
        public Cart Cart { get; set; } = null!;
    }
}
