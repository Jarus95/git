using Microsoft.AspNetCore.Mvc;
using StaticFiles.Mvc.Services;

namespace StaticFiles.Mvc.Controllers;

public class HomeController : Controller
{
    public string Index(int? id)
    {
        var questions = new QuestionsRepository();
        return $"Hello World. {questions.Questions.Count}";
    }
}