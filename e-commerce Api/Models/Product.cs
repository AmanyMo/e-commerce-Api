using System.ComponentModel.DataAnnotations;
namespace e_commerce_Api.Models
{
    public enum FeaturesOption
    {
        Featured,
        NotFeatured

    }
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string ProdName { get; set; } = string.Empty;

        public string ProdDescription { get; set; } = string.Empty;

        [Required, DataType(DataType.Currency)]
        public int? Price { get; set; }

        public string ImagePath { get; set; } = string.Empty;
        [Required]
        public int? Quantity { get; set; }

        [Required]
        public FeaturesOption? Featured { get; set; }
        [Required]
        public int? Cat_Id { get; set; }

        public Categories? CategoriesNav { get; set; }



    }
}
