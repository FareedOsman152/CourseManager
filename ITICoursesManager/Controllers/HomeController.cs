using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ITICoursesManager.Models;

namespace ITICoursesManager.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Addsession(string Name)
    {
        HttpContext.Session.SetString("Name", Name);
        return Content("Session Success");
    }

    public IActionResult AddCookies(string Name)
    {
        Response.Cookies.Append("Name", Name, new CookieOptions
        {
            Expires = DateTime.Now.AddDays(30)
        });
        return Content("Add Cookies Success");
    }

    public IActionResult Getookies()
    {
        var name = Request.Cookies["Name"];
        return Content($"The name from Cookies is : {name}");
    }
    public IActionResult GetSessionData()
    {
        return Content($"The Name From Session : {HttpContext.Session.GetString("Name")}");
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

