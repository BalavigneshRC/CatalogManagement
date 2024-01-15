using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogManagement.Shared.Entities
{
    public class Products
    {
        [Key]
        public int Product_ID { get; set;}
        public string Product_Name { get; set;} = string.Empty;

        [ForeignKey(nameof(Category_ID))]
        public int Category_ID { get; set;}
        public float Price { get; set; }
        public int Available_Stock { get; set; }
    }
}
