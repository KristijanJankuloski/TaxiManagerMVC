using Microsoft.AspNetCore.Mvc;
using TaxiManager.Models;
using TaxiManager.Services.Interfaces;

namespace TaxiManager.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            List<User> users = _userService.GetAll();
            return View(users);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (user == null)
                return Redirect("Register");

            if (user.Username == "" || user.Password == "")
                return Redirect("Register");

            _userService.Add(user);
            return Redirect("Index");
        }
    }
}
