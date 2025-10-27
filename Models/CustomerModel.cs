using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapQuayVideo.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required, StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required, StringLength(255)]
        public string HashedPassword { get; set; } = string.Empty;

        [Required, StringLength(255)]
        public string CustomerAddress { get; set; } = string.Empty;

        [Required, StringLength(10)]
        [Phone]                                 //định dạng số điện thoại hợp lệ
        public string PhoneNumber { get; set; } = string.Empty;

        [Required, StringLength(50)]
        [EmailAddress]                          // định dạng email hợp lệ (có @, ., v.v.)
        public string Email { get; set; } = string.Empty;

        [DefaultValue(1)]                       //giá trị mặc định = 1
        public byte States { get; set; }   // 0 = Inactive, 1 = Active
    }
}
