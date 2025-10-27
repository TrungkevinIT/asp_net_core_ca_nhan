using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapQuayVideo.Models
{
    [Table("Bills")]
    public class Bills
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]                                 //  [Required]: bắt buộc giá trị đó không được null
        [ForeignKey("Products")]                   // FK to Products
        public int ProductId { get; set; }

        [Required]
        [ForeignKey("Customers")]                  // FK to Customers
        public int CustomerId { get; set; }

        [Required]
        [ForeignKey("Staffs")]                     // FK to Staffs
        public int StaffId { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        [Required]
        public int TotalItems { get; set; }    // Total quantity

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; } // Total payment
    }
}
