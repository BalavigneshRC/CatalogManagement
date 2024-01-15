using CatalogManagement.Shared.Entities;

namespace CatalogManagement.Shared.Services
{
    public interface IProductServices
    {
        Task<List<Products>> GetAllProducts();
        Task<Products> GetProductByID(int id);
        Task<List<Products>> GetProductByCategory(int category_ID);
        Task AddProduct(Products newProduct);
        Task<bool> UpdateProduct(Products _product);
        Task<bool> RemoveProduct(int id);
        Task<bool> RemoveProductByCategory(int category_ID);
    }
}
