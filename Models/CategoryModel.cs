using System.ComponentModel;
using System.ComponentModel.DataAnnotations;// nap thu vien cac chu thich co ban ve vadition co ban dung cho kiem tra loi form
using System.ComponentModel.DataAnnotations.Schema;// thu vien Annotations  danh rieng cho luoc do databse
namespace BaiTapQuayVideo.Models
{
    [Table("Categories")]
    public class Categories
    {
        [Key]//khoa chinh
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//id tang tu dong
        public int CategoryId { get; set; }
        //du lieu khong dc de trong neu null thi se thong bao loi
        //khong duoc qua 100 ki tu
        [StringLength(100)]
        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Tên danh mục là bắt buộc, không được để trống")]
        public string CategoryName { get; set; }// gan gia tri mac dinh la chuoi rong

        [Required]
        [DefaultValue(1)]
        public byte States { get; set; }

        [Required(ErrorMessage = "Slug là bắt buộc, không được để trống")]
        [StringLength(150)]
        public string? Slug { get; set; }
        [ForeignKey("ParentId")]//khoa ngoai

        public virtual Categories? ParentCategory { get; set; }
    }
}
