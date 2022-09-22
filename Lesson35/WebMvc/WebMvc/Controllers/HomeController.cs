using Microsoft.AspNetCore.Mvc;

namespace WebMvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Title = "Home page";
        return View();
    }
}