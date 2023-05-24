using TaxiManager.Models.Models;
using TaxiManager.DataAccess.Repositories;
using TaxiManager.DataAccess.Repositories.Interfaces;
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

        public bool IsAvailable(Car car)
        {
            if(car.AssignedDrivers.Count < 3)
            {
                return true;
            }
            return false;
        }

        public void Update(Car car)
        {
            _carRepository.Update(car);
        }
    }
}
