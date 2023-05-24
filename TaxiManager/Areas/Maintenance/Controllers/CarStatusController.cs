using Microsoft.AspNetCore.Mvc;
using TaxiManager.Models.Models;
using TaxiManager.Services.Interfaces;

namespace TaxiManager.Areas.Maintenance.Controllers
{
    [Area("Maintenance")]
    public class CarStatusController : Controller
    {
        private ICarService _carService;
        public CarStatusController(ICarService carService)
        {
            _carService = carService;
        }
        public IActionResult Index()
        {
            List<Car> cars = _carService.GetAll();
            return View(cars);
        }
    }
}
