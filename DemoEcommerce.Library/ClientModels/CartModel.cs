using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DemoEcommerce.Library.ClientModels
{
    public class CartModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        [DataType(DataType.Currency)]
        public double ProductPrice { get; set; } = 0;
        public int OrderQuantity { get; set; } = 0;
        public string? ProductImage { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName ="decimal(18,2)")]
        private decimal subTotal;
        public decimal SubTotal
        {
            get { return (decimal)(ProductPrice * OrderQuantity); }
            set { subTotal = value; }
        }
    }
}
