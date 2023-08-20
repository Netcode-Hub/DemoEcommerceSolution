using DemoEcommerce.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DemoEcommerce.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;
        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        
       // public static string BaseAddress = "https://qpf4bs9j-7234.uks1.devtunnels.ms";
        public static string BaseAddress = "https://localhost:7234";
        public async Task<ServiceResponse> AddProductAsync(Product product)
        {

            var response = await httpClient.PostAsJsonAsync($"{BaseAddress}/api/Products", product);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse>();
            return result;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = await httpClient.GetAsync($"{BaseAddress}/api/Products/categories");
            var response = await categories.Content.ReadFromJsonAsync<List<Category>>();
            return response;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await httpClient.GetAsync($"{BaseAddress}/api/Products");
            var response = await products.Content.ReadFromJsonAsync<List<Product>>();
            return response;
        }
    }
}
