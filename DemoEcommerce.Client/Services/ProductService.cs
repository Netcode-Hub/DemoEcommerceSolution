using DemoEcommerce.Library.ClientModels;
using DemoEcommerce.Library.Responses;
using System.Net.Http.Json;
namespace DemoEcommerce.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;
        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        private static string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://hr2swwjh-7234.uks1.devtunnels.ms" : "https://localhost:7234";
        public async Task<ServiceResponse> AddProductAsync(ProductModel product)
        {

            var response = await httpClient.PostAsJsonAsync($"{BaseAddress}/api/Products", product);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse>();
            return result;
        }

        public async Task<List<CategoryModel>> GetCategoriesAsync()
        {
            var categories = await httpClient.GetAsync($"{BaseAddress}/api/Products/categories");
            var response = await categories.Content.ReadFromJsonAsync<List<CategoryModel>>();
            return response;
        }

        public async Task<List<ProductModel>> GetProductsAsync()
        {
            var products = await httpClient.GetAsync($"{BaseAddress}/api/Products");
            var response = await products.Content.ReadFromJsonAsync<List<ProductModel>>();
            return response;
        }
    }
}
