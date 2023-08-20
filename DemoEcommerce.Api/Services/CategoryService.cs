using DemoEcommerce.Api.Data;
using DemoEcommerce.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoEcommerce.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext appDbContext;

        public CategoryService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<Category>> GetCategoriesAsync() => await appDbContext.Categories.ToListAsync();
    }
}
