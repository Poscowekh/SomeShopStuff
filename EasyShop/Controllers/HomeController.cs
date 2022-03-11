using System.Diagnostics;
using EasyShop.Data;
using Microsoft.AspNetCore.Mvc;
using EasyShop.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) => _logger = logger;

    public IActionResult Index() => View();
    public IActionResult Privacy() => View();

    public IActionResult SignUp() => View();
    public IActionResult SignUpWithForm(UserRegisterForm form)
    {
        using (var db = new AppDbContext())
        {
            // try
            // {
            //     db.Users.Add(new User(form));
            // }
            // catch (Exception e)
            // {
            //     return Error();
            // }
        };
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}