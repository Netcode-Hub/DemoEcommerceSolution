using DemoEcommerce.Library.ClientModels;
using DemoEcommerce.Library.Responses;
namespace DemoEcommerce.Client.Services
{
    public interface ICartService
    {
        Task<ServiceResponse> AddToCartAsync(CartModel cart);
        Task<List<CartModel>> GetMyCartAsync();
    }
}
