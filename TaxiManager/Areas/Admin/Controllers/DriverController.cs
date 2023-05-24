using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxiManager.Models.Models;
using TaxiManager.Services.Interfaces;
using TaxiManager.Utils;

namespace TaxiManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.ADMIN)]
    public class DriverController : Controller
    {
        private IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public IActionResult Index()
        {
            List<Driver> drivers = _driverService.GetAll();
            return View(drivers);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Driver driver)
        {
            if (ModelState.IsValid)
            {
                _driverService.Add(driver);
                TempData["success"] = "Driver added successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Driver driver = _driverService.GetById((int)id);
            if (driver == null)
            {
                return NotFound();
            }
            return View(driver);
        }

        [HttpPost]
        public IActionResult Edit(Driver driver)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _driverService.UpdateInfo(driver);
                    TempData["success"] = "Driver updated successfully";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
                return NotFound();
            Driver driver = _driverService.GetById((int)id);
            if(driver == null)
                return NotFound();
            return View(driver);
        }

        [HttpPost]
        public IActionResult Delete(Driver driver)
        {
            try
            {
                _driverService.DeleteById(driver.Id);
                TempData["success"] = "Driver deleted successfully";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
