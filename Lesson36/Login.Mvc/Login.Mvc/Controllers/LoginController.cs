using Login.Mvc.Models;
using Login.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Login.Mvc.Controllers;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        //agar cookie mavjud bolmasa login pagega yuborish kerak
        if (HttpContext.Request.Cookies.ContainsKey("UserIndex"))
        {
            // user index mavjud 
            var userIndex = int.Parse(HttpContext.Request.Cookies["UserIndex"]);

            //userni indexi listni countidan katta bob ketmasligi kerak
            if (UsersRepository.Users.Count <= userIndex)
            {
                //agar katta bolsa login page ga yuborilsin
                return RedirectToAction("LoginUser");
            }
            
            //userni malumotlarini viewga yuborish
            var user = UsersRepository.Users[userIndex];
            ViewBag.UserExists = true;
            ViewBag.User = user;
        }
        else
        {
            //mavjud emas
            return RedirectToAction("LoginUser");
        }

        return View();
    }

    //ro'yxatdan otish page
    public IActionResult LoginNewUser()
    {
        return View();
    }

    //royxatdan otgan user malumotlarini saqlab indexini cookiega qaytarish
    public IActionResult RegisterUser(User user)
    {
        //userni malumotlarini saqlash
        UsersRepository.Users.Add(user);

        //userni qaysi indexga saqlangani haqida malumotni cookiega saqlash
        var userIndex = UsersRepository.Users.IndexOf(user);
        HttpContext.Response.Cookies.Append("UserIndex", userIndex.ToString());

        return RedirectToAction("Index");
    }


    public IActionResult LoginUser()
    {
        return View();
    }

    //user login page
    public IActionResult UserSignin(User user)
    {
        //user kiritgan malumotlariga qarab listda bormi yuqmi tekshirish
        if (UsersRepository.Users.Any(u => u.PhoneNumber == user.PhoneNumber))
        {
            var _user = UsersRepository.Users.First(u => u.PhoneNumber == user.PhoneNumber);
            if (user.Password == _user.Password)
            {
                //agar user togri malumotlarni kiritgan bolsa indexini saqlab main pagega yuborish
                var userIndex = UsersRepository.Users.IndexOf(_user);
                HttpContext.Response.Cookies.Append("UserIndex", userIndex.ToString());
                return RedirectToAction("Index");
            }
        }

        return RedirectToAction("LoginUser");
    }
}