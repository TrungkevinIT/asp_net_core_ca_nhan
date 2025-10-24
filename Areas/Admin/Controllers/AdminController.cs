using BaiTapQuayVideo.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapQuayVideo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        // biến có kiểu ProductServices
        private ProductServices _productServices;
        private CategoryServices _categoryServices;
        // hàm khởi tạo AdminController
        public AdminController(ProductServices productServices, CategoryServices categoryServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
        }

        public IActionResult Management()
        {
            ViewData["Title"] = "Management";
            ViewBag.Message = "Page Management";
            return View();
        }
        public IActionResult ProductManagement()
        {
            ViewData["Title"] = "ProductManagement";
            ViewBag.Message = "Page ProductManagement";
            var product = _productServices.GetAllProducts();
            return View(product);
        }
        public IActionResult CategoryManagement()
        {
            ViewData["Title"] = "CategoryManagement";
            ViewBag.Message = "Page CategoryManagement";
            var category = _categoryServices.GetAllCategories();
            return View(category);
        }
    }
}
