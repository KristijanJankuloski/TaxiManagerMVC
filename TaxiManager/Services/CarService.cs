using TaxiManager.Models;
using TaxiManager.Repositories;
using TaxiManager.Repositories.Interfaces;
using TaxiManager.Services.Interfaces;

namespace TaxiManager.Services
{
    public class CarService : ICarService
    {
        private ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public void Add(Car car)
        {
            _carRepository.Add(car);
        }

        public void DeleteById(int id)
        {
            _carRepository.DeleteById(id);
        }

        public List<Car> GetAll()
        {
            return _carRepository.GetAll();
        }

        public List<Car> GetAvailable()
        {
            return _carRepository.GetAvailable();
        }

        public Car GetById(int id)
        {
            return _carRepository.GetById(id);
        }
    }
}
