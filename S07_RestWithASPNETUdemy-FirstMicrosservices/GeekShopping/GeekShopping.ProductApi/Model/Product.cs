using GeekShopping.ProductApi.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductApi.Model
{
    /*Annotation for case other table name in database */
    [Table("Product")]
    public class Product : BaseEntity
    {
        /*Annotation for case other table name in database */
        [Column("Name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }
        
        [StringLength(500)]
        public string Description { get; set; }
        
        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(300)]
        public string ImageUrl { get; set; }
    }
}
