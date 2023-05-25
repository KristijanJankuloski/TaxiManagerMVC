using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaxiManager.Models.Models;
using TaxiManager.Services.Interfaces;
using TaxiManager.Utils;

namespace TaxiManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.ADMIN)]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            List<IdentityUser> users = _userManager.Users.ToList();
            return View(users);
        }

        public IActionResult Delete(string id)
        {
            IdentityUser user = _userManager.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(IdentityUser user)
        {
            if (user == null)
            {
                return NotFound();
            }
            var foundUser = _userManager.FindByIdAsync(user.Id).GetAwaiter().GetResult();
            var result = _userManager.DeleteAsync(foundUser).GetAwaiter().GetResult();
            TempData["success"] = "User deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

//namespace TaxiManager.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    public class UserController : Controller
//    {
//        private readonly IUserService _userService;
//        public UserController(IUserService userService)
//        {
//            _userService = userService;
//        }

//        public IActionResult Index()
//        {
//            List<User> users = _userService.GetAll();
//            return View(users);
//        }

//        public IActionResult Register()
//        {
//            return View();
//        }
//        [HttpPost]
//        public IActionResult Register(User user)
//        {
//            if (ModelState.IsValid)
//            {
//                _userService.Add(user);
//                TempData["success"] = "User registered successfully";
//                return RedirectToAction("Index");
//            }
//            return View();
//        }

//        public IActionResult Delete(int? id)
//        {
//            if (id == null || id == 0)
//                return NotFound();
//            try
//            {
//                User userToDelete = _userService.GetById((int)id);
//                return View(userToDelete);
//            }
//            catch (Exception ex)
//            {
//                return NotFound();
//            }
//        }

//        [HttpPost]
//        public IActionResult Delete(User user)
//        {
//            if (user == null)
//                return NotFound();
//            try
//            {
//                _userService.DeleteById(user.Id);
//                TempData["success"] = "User deleted successfully";
//                return RedirectToAction("Index");
//            }
//            catch (Exception ex)
//            {
//                TempData["error"] = ex.Message;
//                return RedirectToAction("Index");
//            }
//        }
//    }
//}

