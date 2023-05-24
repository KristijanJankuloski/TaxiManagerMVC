using Microsoft.AspNetCore.Mvc;
using TaxiManager.Models.Models;
using TaxiManager.Models.ViewModels;
using TaxiManager.Services.Interfaces;

namespace TaxiManager.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class DriverAssignController : Controller
    {
        private IDriverService _driverService;
        private ICarService _carService;
        public DriverAssignController(IDriverService driverService, ICarService carService)
        {
            _driverService = driverService;
            _carService = carService;

        }
        public IActionResult Index()
        {
            List<Driver> availableDrivers = _driverService.GetNotAssigned();
            return View(availableDrivers);
        }

        public IActionResult AssignToCar(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Driver driver = _driverService.GetById((int)id);
            if (driver == null)
            {
                return NotFound();
            }
            List<Car> cars = _carService.GetAvailable();
            AssignDriverVM driverVM = new AssignDriverVM(driver, cars);
            return View(driverVM);
        }

        [HttpPost]
        public IActionResult AssignToCar(int id)
        {
            TempData["success"] = id;
            return RedirectToAction("Index");
        }
    }
}
