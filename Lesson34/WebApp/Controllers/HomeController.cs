using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public string GetName()
    {
        return "Name: Bootcamp";
    }

    public int Add(int a, int b)
    {
        return a + b;
    }


}