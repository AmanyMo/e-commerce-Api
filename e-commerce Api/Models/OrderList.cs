using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace e_commerce_Api.Models
{
    enum stage { pending , delivered , cancelled }
    public class OrderList
    {
        [Key]
        public int OrderID { get; set; }
        [Required, StringLength(20)]  
        public string OrderStage { get; set; }
        [Required, DefaultValue("Egypt")]
        public string OrderAddress { get; set; }
        [Required]
        public double OrderTotalPrice { get; set; }
        [ForeignKey("User")]
        public int User_Id { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
