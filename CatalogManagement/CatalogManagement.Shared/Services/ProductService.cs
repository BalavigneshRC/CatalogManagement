using CatalogManagement.Shared.Data;
using CatalogManagement.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogManagement.Shared.Services
{
    public class ProductService : IProductServices
    {
        private readonly CatalogDBContext catalogDBContext;

        public ProductService(CatalogDBContext _catalogDBContext) 
        {
            catalogDBContext = _catalogDBContext;
        }
        public async Task AddProduct(Products newProduct)
        {
            _ = catalogDBContext.Products.AddAsync(newProduct);
            await catalogDBContext.SaveChangesAsync();
        }

        public async Task<List<Products>> GetProductByCategory(int category_ID)
        {
            var products = await catalogDBContext.Products.Where(product => product.Category_ID == category_ID).ToListAsync();
            return products;
        }

        public async Task<Products> GetProductByID(int id)
        {
            var Product = await catalogDBContext.Products.FindAsync(id);
            return Product;
        }

        public async Task<List<Products>> GetAllProducts()
        {
            var Product = await catalogDBContext.Products.ToListAsync();
            return Product;
        }

        public async Task<bool> RemoveProduct(int id)
        {
            var Product = await catalogDBContext.Products.FindAsync(id);
            if (Product == null) { return false; }
            _ = catalogDBContext.Products.Remove(Product);
            await catalogDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveProductByCategory(int category_ID)
        {
            var products = await catalogDBContext.Products.Where(product => product.Category_ID == category_ID).ToListAsync();
            if (products == null) { return false; }
            foreach (var product in products) {
                _ = catalogDBContext.Products.Remove(product);
            }
            await catalogDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProduct(Products _product)
        {
            var result = await catalogDBContext.Products.FindAsync(_product.Product_ID);
            if (result == null) { return false; }
            result.Price = _product.Price;
            result.Product_Name = _product.Product_Name;
            result.Available_Stock = _product.Available_Stock;
            result.Category_ID = _product.Category_ID;
            await catalogDBContext.SaveChangesAsync();
            return true;
        }
    }
}
