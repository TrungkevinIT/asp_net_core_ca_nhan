using BaiTapQuayVideo.Models;
using BaiTapQuayVideo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Threading.Tasks;

namespace BaiTapQuayVideo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private ProductServices _productsService;
        public ProductController (ProductServices productServices)
        {
            _productsService = productServices;
        }
        //dùng để truy cập trang thêm sản phẩm
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }
        //dùng để xử lý form trang thêm sản phẩm
        //[HttpPost]
        //public IActionResult CreateProduct(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        bool category = _productsService.AddProducts(product);
        //        // nếu đúng thì trả về true có nghĩa là thêm sản phẩm thành công
        //        if (category)
        //        {
        //            return RedirectToAction("ProductManagement", "Admin", new { erea = "Admin" });
        //        }
        //    }
        //    return View(product);
        //}
       
        [HttpPost]
        public async Task<IActionResult> PostWithImage([FromForm] ProductImage p)
        {
            // Nếu Model không hợp lệ (ví dụ: thiếu ProductName),
            // ta phải trả về View với DTO 'p' ngay lập tức
            // để hiển thị lại các giá trị người dùng đã nhập.
            if (!ModelState.IsValid)
            {
                return View(p);
            }

            // Từ đây trở đi, Model ĐÃ HỢP LỆ
            var product = new Product
            {
                CategoryId = p.CategoryId,
                ProductName = p.ProductName,
                Price = p.Price,
                PromotionPrice = p.PromotionPrice,
                ProductDescription = p.ProductDescription,
                TagName = p.TagName,
                ProductType = p.ProductType,
                States = p.States
            };
            var imageNames = new List<string>();
            //xu ly anh
            // Thêm p.Image != null để tránh lỗi khi người dùng không upload file
            if (p.Images.Count > 0)
            {
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", "products");
                foreach(var imageFile in p.Images)
                {
                    if (imageFile.Length>0)
                    {
                        // Tránh việc 2 người dùng upload file 'image.jpg' sẽ bị ghi đè lên nhau
                        string fileExtension = Path.GetExtension(imageFile.FileName);
                        string uniqueFileName = Guid.NewGuid().ToString() + fileExtension;

                        // 5. Tạo đường dẫn đầy đủ để lưu file
                        var path = Path.Combine(uploadPath, uniqueFileName);
                        using (var stream = System.IO.File.Create(path))
                        {
                            await imageFile.CopyToAsync(stream);
                        }
                        imageNames.Add(uniqueFileName);
                    }
                }
                product.ImageUrl = string.Join(",", imageNames);


            }
            else
            {
                product.ImageUrl = "";
            }

            bool category = _productsService.AddProducts(product);

            if (category)
            {
                return RedirectToAction("ProductManagement", "Admin", new { area = "Admin" });
            }

            // Nếu thêm thất bại (category = false), ta trả về View với 'product'
            // Dòng 'return View(product);' của bạn phải nằm ở đây.
            return View(p);
        }
    }
}
