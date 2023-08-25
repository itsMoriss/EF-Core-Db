namespace AssessmentDb.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; } 
        
        // Navigation properties
        public List<Order> Orders { get; set; } = null!;
        public List<Cart> Carts { get; set; } = null!;
    }
}
