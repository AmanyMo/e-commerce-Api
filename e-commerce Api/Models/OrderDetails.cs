using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace e_commerce_Api.Models
{
    public class OrderDetails
    {
        [Required]
        public int OrderID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required,DefaultValue(1)]
        public int Quantity { get; set; }


        [JsonIgnore]
        public virtual OrderList Order { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual Products Products { get; set; }


    }
}
