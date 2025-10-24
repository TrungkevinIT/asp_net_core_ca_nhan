using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BaiTapQuayVideo.Models
{
    public class ProductImage
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc, không được để trống")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Giá gốc là bắt buộc, không được để trống")]
        public decimal Price { get; set; }

        public decimal PromotionPrice { get; set; }

        [Required(ErrorMessage = "Mô tả là bắt buộc, không được để trống")]
        public string? ProductDescription { get; set; }
        [Required(ErrorMessage = "Tên danh mục là bắt buộc, không được để trống")]
        public string? TagName { get; set; }
        [Required(ErrorMessage = "TagName là bắt buộc, không được để trống")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Mã danh mục là bắt buộc, không được để trống")]// FK to Categories
        public string? ProductType { get; set; }     // Kiểu NVARCHAR(255)
        [Required(ErrorMessage = "Tên danh mục là bắt buộc, không được để trống")]
        public int States { get; set; }
        [Required(ErrorMessage = "Urlimage là bắt buộc, không được để trống")]
        public List<IFormFile> Images { get; set; }
    }
}
