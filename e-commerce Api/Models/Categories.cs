using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace e_commerce_Api.Models
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; } = string.Empty;

        [JsonIgnore]
        public  ICollection<Products> ProductList { get; set; }

    }
}