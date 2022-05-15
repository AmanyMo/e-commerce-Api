using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace e_commerce_Api.Models
{
    enum stage { pending , delivered , cancelled }
    public class OrderList
    {
        [Key]
        public int OrderID { get; set; }
        [Required]  
        public string OrderStage { get; set; }
        [Required, DefaultValue("Egypt")]
        public string OrderAddress { get; set; }
        [Required]
        public double OrderTotalPrice { get; set; }
        public ICollection<Products> ProductList { get; set; }
    }
}
