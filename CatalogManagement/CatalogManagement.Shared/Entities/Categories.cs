using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogManagement.Shared.Entities
{
    public class Categories
    {
        [Key]
        public int Category_ID { get; set; }
        public string? Category_Name { get; set; }
    }
}
