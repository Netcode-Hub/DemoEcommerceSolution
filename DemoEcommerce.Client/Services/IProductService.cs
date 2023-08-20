
using DemoEcommerce.Client.Models;

namespace DemoEcommerce.Client.Services
{
    public interface IProductService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<ServiceResponse> AddProductAsync(Product product);
        Task<List<Product>> GetProductsAsync();
    }
}
