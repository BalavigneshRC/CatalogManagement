using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogManagement.Shared.Entities
{
    public class Properties
    {
        [Key]
        public int Property_ID { get; set; }

        [ForeignKey(nameof(Product_ID))]
        public int Product_ID { get; set; }
        public string Property_Name { get; set; } = string.Empty;
        public string Property_Value { get; set; } = string.Empty;
    }
}
