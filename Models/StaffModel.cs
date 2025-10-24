using System.ComponentModel;
using System.ComponentModel.DataAnnotations;// nap thu vien cac chu thich co ban ve vadition co ban dung cho kiem tra loi form
using System.ComponentModel.DataAnnotations.Schema;// thu vien Annotations  danh rieng cho luoc do databse
namespace BaiTapQuayVideo.Models
{
    public class StaffModel
    {
        [Table("Staffs")]
        public class Staff
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int UserId { get; set; }

            [Required(ErrorMessage = "Username is required")]
            [StringLength(100)]
            public string Username { get; set; } = string.Empty;

            [Required(ErrorMessage = "Password is required")]
            [StringLength(255)]
            [DataType(DataType.Password)]
            public string HashedPassword { get; set; } = string.Empty;

            [Required]
            [Phone]
            [StringLength(10, MinimumLength = 9, ErrorMessage = "Phone number must be 9–10 digits")]
            public string PhoneNumber { get; set; } = string.Empty;

            [Required]
            [EmailAddress]
            [StringLength(50)]
            public string Email { get; set; } = string.Empty;

            [Required, StringLength(255)]
            public string StaffAddress { get; set; } = string.Empty;

            [DefaultValue(1)]
            public byte States { get; set; }   // 0 = Inactive, 1 = Active

            [Required]
            public byte Roles { get; set; }    // 0 = Staff, 1 = Admin
        }
    }
}
