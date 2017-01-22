using ShopKhanh.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopKhanh.Model.Models
{
    [Table("ProductCategories")]
    public class ProductCategory :Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        public string Name { set; get; }
        public string Alias { set; get; }
        [Required]
        public string Description { set; get; }
        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }
        public string Images { set; get; }
        public bool? HomeFlag { set; get; }
        public virtual IEnumerable<Product> Products { set; get; }
            
    }
}
