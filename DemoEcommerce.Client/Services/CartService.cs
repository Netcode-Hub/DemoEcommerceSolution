using DemoEcommerce.Library.ClientModels;
using DemoEcommerce.Library.Responses;

namespace DemoEcommerce.Client.Services
{
    public class CartService : ICartService
    {
        public async Task<ServiceResponse> AddToCartAsync(CartModel cart)
        {
            if (App.MyCart is not null)
            {
                var checkProduct = App.MyCart.Where(_ => _.ProductId == cart.ProductId).FirstOrDefault();
                if (checkProduct is not null)
                {
                    if (checkProduct.OrderQuantity == cart.OrderQuantity) return new ServiceResponse() { Message = "Product added already", Success = false };

                    //update the product quantity
                    var updatedCart = new CartModel() { 
                        OrderQuantity = cart.OrderQuantity,
                        ProductId = checkProduct.ProductId, 
                        ProductPrice = checkProduct.ProductPrice,
                        ProductName = checkProduct.ProductName, 
                        ProductImage = checkProduct.ProductImage };

                    App.MyCart.Remove(checkProduct);
                    App.MyCart.Add(updatedCart);
                    return new ServiceResponse() { Message = "Product updated", Success = true };
                }

                //add new item
                App.MyCart.Add(cart);
                return new ServiceResponse() { Message = "Product added to cart", Success = true };
            }
            // do it for the first time
            App.MyCart.Add(cart);
            return new ServiceResponse() { Message = "Product added to cart", Success = true };
        }

        public async Task<List<CartModel>> GetMyCartAsync()
        {
            var productsInCart = App.MyCart;
            if (productsInCart.Count == 0) return null;

            var carts = new List<CartModel>();
            foreach (var cart in productsInCart)
                carts.Add(cart);

            return carts.ToList();

        }
    }
}
