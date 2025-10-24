using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BaiTapQuayVideo.Models;

namespace BaiTapQuayVideo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.isIndex = true;
        return View();
    }

    public IActionResult Single()
    {
        return View();
    }


    public IActionResult Bicycles()
    {
        ViewBag.pageName = "Bicycles";
        return View();
    }

    public IActionResult Parts()
    {
        ViewBag.pageName = "Parts";
        return View();
    }

    public IActionResult Cart()
    {
        return View();
    }

    public IActionResult Accessories()
    {
        ViewBag.pageName = "Accessories";
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }
}
