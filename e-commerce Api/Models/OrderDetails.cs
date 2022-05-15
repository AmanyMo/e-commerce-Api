using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace e_commerce_Api.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderID { get; set; }
        [Key]
        public int ProductID { get; set; }
        [Key]
        public int UserID { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required,DefaultValue(1)]
        public int Quantity { get; set; }

        public virtual OrderList Order { get; set; }
        public virtual User User { get; set; }
        public virtual Products Products { get; set; }


    }
}
