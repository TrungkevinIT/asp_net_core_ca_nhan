using BaiTapQuayVideo.Services;
using Microsoft.AspNetCore.Mvc;
using BaiTapQuayVideo.Models;
namespace BaiTapQuayVideo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        //khai báo biến tham chiếu đến CategoryServices
        private readonly CategoryServices _categoryservices;
        //gán biến tham chiếu vào hàm khởi tạo CategoryController để có thể sử dụng phương thức của CategoryServices
        public CategoryController(CategoryServices categoryservices)
        {
            _categoryservices = categoryservices;
        }
        //chỉ hiện ra giao diện thêm sản danh mục
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        //xử lý với from thêm danh mục
        [HttpPost]
        public IActionResult CreateCategory(Categories categories)
        {
            if (ModelState.IsValid)
            {
                bool category = _categoryservices.AddCategory(categories);
                // nếu đúng thì trả về true có nghĩa là thêm sản phẩm thành công
                if (category)
                {
                    return RedirectToAction("CategoryManagement", "Admin", new { erea = "Admin" });
                }
            }
                return View(categories);
        }

    }
}
