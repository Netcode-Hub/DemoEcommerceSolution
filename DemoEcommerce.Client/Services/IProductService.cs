
using DemoEcommerce.Library.ClientModels;
using DemoEcommerce.Library.Responses;

namespace DemoEcommerce.Client.Services
{
    public interface IProductService
    {
        Task<List<CategoryModel>> GetCategoriesAsync();
        Task<ServiceResponse> AddProductAsync(ProductModel product);
        Task<List<ProductModel>> GetProductsAsync();
    }
}
