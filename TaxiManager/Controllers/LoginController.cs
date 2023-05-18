using Microsoft.AspNetCore.Mvc;

namespace TaxiManager.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index(string? error)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            if (!form.ContainsKey("username") || !form.ContainsKey("password")) {
                return Redirect("/login?error=invalid_login");
            }
            if (form["username"] == "" || form["password"] == "")
            {
                return Redirect("/login?error=invalid_login");
            }
            return Redirect("/home");
        }
    }
}
