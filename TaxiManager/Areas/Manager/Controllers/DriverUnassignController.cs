using Microsoft.AspNetCore.Mvc;
using TaxiManager.Models.Models;
using TaxiManager.Services.Interfaces;

namespace TaxiManager.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class DriverUnassignController : Controller
    {
        private IDriverService _driverService;

        public DriverUnassignController(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public IActionResult Index()
        {
            List<Driver> drivers = _driverService.GetAssigned();
            return View(drivers);
        }

        public IActionResult Unassign(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Driver driver = _driverService.GetById((int)id);
            return View(driver);
        }

        [HttpPost]
        public IActionResult Unassign(Driver driver)
        {
            try
            {
                _driverService.Unassign(driver.Id);
                TempData["success"] = "Driver unassigned from car";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return Redirect("Index");
            }
        }
    }
}
