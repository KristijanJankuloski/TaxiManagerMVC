using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxiManager.Models.Models;
using TaxiManager.Services.Interfaces;
using TaxiManager.Utils;

namespace TaxiManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.ADMIN)]
    public class CarController : Controller
    {
        private ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            List<Car> cars = _carService.GetAll();
            return View(cars);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Car car)
        {
            if (ModelState.IsValid)
            {
                _carService.Add(car);
                TempData["success"] = "Car added successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["error"] = "Car not found";
                return RedirectToAction("Index");
            }
            Car car = _carService.GetById((int)id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        public IActionResult Edit(Car car)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _carService.Update(car);
                    TempData["success"] = "Car updated successfully";
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
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Car car = _carService.GetById((int)id);
            if (car == null)
                return NotFound();
            return View(car);
        }

        [HttpPost]
        public IActionResult Delete(Car car)
        {
            try
            {
                _carService.DeleteById(car.Id);
                TempData["success"] = "Car deleted successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
