
namespace DemoEcommerce.Library.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set;}
        public string Image { get; set; }
    }
}
