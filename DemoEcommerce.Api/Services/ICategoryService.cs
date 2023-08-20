using DemoEcommerce.Library.Models;

namespace DemoEcommerce.Api.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
    }
}
