using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using desafio_web.Models;
using Microsoft.AspNetCore.Http.Extensions;
using desafio_web.Utils;

namespace desafio_web.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;
    private readonly UsuarioDbContext _context;

    public LoginController(ILogger<LoginController> logger, UsuarioDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Logon(string userIn, string passIn)
    {
        var usuario = _context.UsuarioModels.FirstOrDefault(
            u =>
            u.Nome.ToUpper().Equals(userIn.ToUpper())
        );

        if (!ValidaUsuario(usuario, passIn))
        {
            @ViewData["Message"] = "Usuário/Senha incorretos";
            return View("Index");
        }

        Response.Cookies.Append("loggedIn", "true");

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logoff()
    {
        Response.Cookies.Delete("loggedIn");
        return RedirectToAction("Index", "Login");
    }

    public IActionResult NewUser()
    {
        @ViewData["Message"] = "";
        return View();
    }

    public IActionResult AddNewUser(string userIn, string passIn)
    {

        @ViewData["Message"] = "";

        var usuario = _context.UsuarioModels.FirstOrDefault(
            u => u.Nome.ToUpper() == userIn.ToUpper()
        );

        if (usuario != null)
        {
            Console.WriteLine("Chegou aqui");
            @ViewData["Message"] = "Usuário já cadastrado";
            return View("NewUser", "Login");
        }

        usuario = new UsuarioModel
        {
            Nome = userIn,
            Senha = MD5Generator.ToMD5(passIn)
        };        

        _context.Add(usuario);
        var s = _context.SaveChanges();        

        if (usuario.Id <= 0)
        {
            @ViewData["Message"] = "Falha ao cadastrar usuário. Tente novamente.";
            return RedirectToAction("NewUser", "Login");
        }

        ViewBag.Sucess = true;
        return View("Index", "Login");
    }

    private bool ValidaUsuario(UsuarioModel? usuario, string senha)
    {
        if (usuario == null)
            return false;

        return MD5Generator.ToMD5(senha) == usuario.Senha;
    }

}
