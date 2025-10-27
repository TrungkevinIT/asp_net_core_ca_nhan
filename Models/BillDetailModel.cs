using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BaiTapQuayVideo.Models
{
    [Table("BillDetail")]                           //chỉ định tên bảng trong CSDL
    public class BillDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }

        [Required]                                 //  [Required]: bắt buộc giá trị đó không được null
        [ForeignKey("Bills")]                      // FK to Bills
        public int OrderId { get; set; }

        [Required]
        [ForeignKey("Products")]
        public int ProductId { get; set; }         // FK to Products

        [Required(ErrorMessage = "Product name is required.")] //Bắt buộc nhập giá trị, đồng thời hiển thị thông báo lỗi tùy chỉnh
        [StringLength(100)]
        public string ProductName { get; set; } = string.Empty; // string.Empty Trường bắt buộc có giá trị

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PromotionPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
    }
}
