using Microsoft.EntityFrameworkCore;
using CatalogManagement.Shared.Data;
using CatalogManagement.Shared.Entities;
namespace CatalogManagement.Shared.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly CatalogDBContext catalogDBContext;

        public CategoryService(CatalogDBContext _catalogDBContext)
        {
            catalogDBContext = _catalogDBContext;
        }
        public async Task AddCategory(Categories newCategory)
        {
            await Task.Delay(1000);
            _ = catalogDBContext.Categories.AddAsync(newCategory);
            await catalogDBContext.SaveChangesAsync();
        }
        public async Task<List<Categories>> GetCategories()
        {
            var Categories = await catalogDBContext.Categories.ToListAsync();
            return Categories;
        }
        public async Task<Categories> GetCategoryByID(int id)
        {
            var Category = await catalogDBContext.Categories.FindAsync(id);
            return Category;
        }
        public async Task<bool> RemoveCategory(int id)
        {
            var Category = await catalogDBContext.Categories.FindAsync(id);
            if (Category == null) { return false; }
            _ = catalogDBContext.Categories.Remove(Category);
            await catalogDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateCategory(Categories _category)
        {
            var result = await catalogDBContext.Categories.FindAsync(_category.Category_ID);
            if (result == null) { return false; }
            result.Category_Name = _category.Category_Name;
            await catalogDBContext.SaveChangesAsync();
            return true;
        }
    }
}
