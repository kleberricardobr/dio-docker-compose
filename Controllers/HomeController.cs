using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using desafio_web.Models;

namespace desafio_web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        var loggedIn = (Request.Cookies["loggedIn"] ?? "false") == "true";
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Login");
        }

        return View();
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
