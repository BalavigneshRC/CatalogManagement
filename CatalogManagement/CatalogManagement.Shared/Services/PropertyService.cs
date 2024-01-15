using CatalogManagement.Shared.Data;
using CatalogManagement.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogManagement.Shared.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly CatalogDBContext catalogDBContext;

        public PropertyService(CatalogDBContext _catalogDBContext)
        {
            catalogDBContext = _catalogDBContext;
        }
        public async Task AddProperty(Properties newProperty)
        {
            _ = catalogDBContext.Properties.AddAsync(newProperty);
            await catalogDBContext.SaveChangesAsync();
        }

        public async Task<List<Properties>> GetProperties()
        {
            var properties = await catalogDBContext.Properties.ToListAsync();
            return properties;
        }

        public async Task<Properties> GetPropertyByID(int id)
        {
            var properties = await catalogDBContext.Properties.FindAsync(id);
            return properties;
        }

        public async Task<List<Properties>> GetPropertyByProduct(int product_ID)
        {
            var properties = await catalogDBContext.Properties.Where(property => property.Product_ID == product_ID).ToListAsync();
            return properties;
        }

        public async Task<bool> RemoveProperty(int id)
        {
            var property = await catalogDBContext.Properties.FindAsync(id);
            if (property == null) { return false; }
            _ = catalogDBContext.Properties.Remove(property);
            await catalogDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> RemovePropertyByProduct(int product_ID)
        {
            var properties = await catalogDBContext.Properties.Where(property => property.Product_ID == product_ID).ToListAsync();
            if (properties == null) { return false; }
            foreach (var property in properties)
            {
                _ = catalogDBContext.Properties.Remove(property);
            }
            await catalogDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProperty(Properties _property)
        {
            var result = await catalogDBContext.Properties.FindAsync(_property.Property_ID);
            if (result == null) { return false; }
            result.Property_Name = _property.Property_Name;
            result.Property_Value = _property.Property_Value;
            await catalogDBContext.SaveChangesAsync();
            return true;
        }
    }
}
