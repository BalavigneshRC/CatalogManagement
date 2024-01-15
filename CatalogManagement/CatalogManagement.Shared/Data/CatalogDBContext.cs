using CatalogManagement.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogManagement.Shared.Data
{
    public class CatalogDBContext : DbContext
    {
        public CatalogDBContext(DbContextOptions<CatalogDBContext> options):base(options)
        {

        }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Properties> Properties { get; set; }
       
    }
}
