using Microsoft.AspNetCore.Mvc;
using TaxiManager.Enums;
using TaxiManager.Models;
using TaxiManager.Services.Interfaces;

namespace TaxiManager.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index(string? error)
        {
            return View("Index",error);
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            if (!form.ContainsKey("username") || !form.ContainsKey("password"))
            {
                return Redirect("/login?error=invalid_input");
            }
            if (form["username"] == "" || form["password"] == "")
            {
                return Redirect("/login?error=invalid_input");
            }
            User user = null;
            try
            {
                user = _userService.Login(form["username"], form["password"]);
            }
            catch (Exception ex)
            {
                return Redirect($"/login?error=invalid_credentials");
            }
            if (user == null)
                return Redirect("/login?error=invalid_credentials");
            return Redirect("/home");
        }
    }
}
