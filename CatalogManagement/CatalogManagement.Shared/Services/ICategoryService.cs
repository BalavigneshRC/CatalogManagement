using CatalogManagement.Shared.Entities;

namespace CatalogManagement.Shared.Services
{
    public interface ICategoryService
    {
        Task<List<Categories>> GetCategories();
        Task<Categories> GetCategoryByID(int id);
        Task AddCategory(Categories newCategory);
        Task<bool> UpdateCategory(Categories _category);
        Task<bool> RemoveCategory(int id);
    }
}
