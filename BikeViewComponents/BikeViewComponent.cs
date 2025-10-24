using Azure.Identity;
using BaiTapQuayVideo.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapQuayVideo.BikeViewComponents
{
    public class BikeViewComponent : ViewComponent
    {
        private ProductServices _productServices;
        public BikeViewComponent(ProductServices productServices)
        {
            _productServices = productServices;
        }
        
        public IViewComponentResult Invoke()
        {
            var bike = _productServices.GetTop6RanDomProducts();
            return View("Index",bike);
        }
    }
}
