using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;
using WebMvc.Services;

namespace WebMvc.Controllers;

public class UsersController : Controller
{
    public IActionResult Index()
    {
        var users = UsersService.Users;
        ViewBag.Title = "Users";
        return View(users);
    }

    public IActionResult Add()
    {
        ViewBag.Title = "Add user";
        return View();
    }

    public IActionResult AddUser(User user)
    {
        UsersService.Users.Add(user);
        ViewBag.Title = "User added";
        return View(user);
    }

    public IActionResult Delete(int i)
    {
        UsersService.Users.RemoveAt(i);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int index)
    {
        var user = UsersService.Users[index];
        ViewBag.Title = "Edit user";
        user.Index = index;
        return View(user);
    }

    public IActionResult EditUser(User user)
    {
        UsersService.Users[user.Index] = user;
        return RedirectToAction("Index");
    }
}