using Microsoft.AspNetCore.Mvc;
using TaxiManager.Models.Models;
using TaxiManager.Services.Interfaces;

namespace TaxiManager.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class DriverStatusController : Controller
    {
        private IDriverService _driverService;
        public DriverStatusController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public IActionResult Index()
        {
            List<Driver> drivers = _driverService.GetAll();
            return View(drivers);
        }
    }
}
