using CatalogManagement.Shared.Entities;

namespace CatalogManagement.Shared.Services
{
    public interface IPropertyService
    {
        Task<List<Properties>> GetProperties();
        Task<Properties> GetPropertyByID(int id);
        Task<List<Properties>> GetPropertyByProduct(int product_ID);
        Task AddProperty(Properties newProperty);
        Task<bool> UpdateProperty(Properties _property);
        Task<bool> RemoveProperty(int id);
        Task<bool> RemovePropertyByProduct(int product_ID);
    }
}
