using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class QuestionController : Controller
{
    public IActionResult Index(int questionIndex, string questionText)
    {
        ViewBag.QuestionIndex = questionIndex;
        ViewBag.QuestionText = questionText;

        return View();
    }

    public IActionResult Add()
    {
        return View();
    }
}