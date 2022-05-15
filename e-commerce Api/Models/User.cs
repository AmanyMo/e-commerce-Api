using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce_Api.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required ,StringLength(50)]
        public string UserName { get; set; }
        [Required,EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        public DateOnly? UserDOB { get; set; }
        [Required,Column(TypeName = "varbinary(MAX)")]
        public byte[] UserImage { get; set; }
        [Required,StringLength(30,MinimumLength =6,ErrorMessage ="length should be between 6 and 30")]
        public string UserPassword { get; set; }
        [Required,NotMapped,Compare("UserPassword",ErrorMessage ="not match")]
        public string UserConfirmPassword { get; set; }
        [Required,DefaultValue("user")]
        public string UserRole { get; set; }
    }
}
