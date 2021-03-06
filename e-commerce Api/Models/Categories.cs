using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace e_commerce_Api.Models
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }
        [Required,StringLength(20)]
        public string CategoryName { get; set; }

        [JsonIgnore]
        public  virtual ICollection<Products> ProductList { get; set; }

    }
}