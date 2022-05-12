
using System.ComponentModel.DataAnnotations;

namespace e_commerce_Api.Models
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<Products>? ProductList { get; set; }

    }
}