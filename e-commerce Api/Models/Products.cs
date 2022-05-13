using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace e_commerce_Api.Models
{

    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        [Required]  
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public int? ProductPrice { get; set; }
        public string ProductImage { get; set; }
        [Required]
        public int? ProductQuantity { get; set; }
        [Required]
        public int? ProductFeatured { get; set; }
        [Required, ForeignKey("Categories")]
        public int? Category_Id { get; set; }


        [JsonIgnore]
        public virtual Categories Categories { get; set; }



    }
}
