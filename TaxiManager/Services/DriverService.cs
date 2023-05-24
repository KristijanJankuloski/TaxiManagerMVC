using TaxiManager.Models.Models;
using TaxiManager.DataAccess.Repositories;
using TaxiManager.DataAccess.Repositories.Interfaces;
using TaxiManager.Services.Interfaces;
using TaxiManager.Models.Enums;

namespace TaxiManager.Services
{
    public class DriverService : IDriverService
    {
        private IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public void Add(Driver driver)
        {
            _driverRepository.Add(driver);
        }

        public void AssignToCar(int driverId, Car car, Shift shift)
        {
            Driver driver = _driverRepository.GetById(driverId);
            driver.Car = car;
            driver.CarId = car.Id;
            driver.Shift = shift;
            _driverRepository.Update(driver);
        }

        public void DeleteById(int id)
        {
            _driverRepository.DeleteById(id);
        }

        public List<Driver> GetAll()
        {
            return _driverRepository.GetAll();
        }

        public List<Driver> GetAssigned()
        {
            return _driverRepository.GetAssigned();
        }

        public Driver GetById(int id)
        {
            return _driverRepository.GetById(id);
        }

        public List<Driver> GetNotAssigned()
        {
            return _driverRepository.GetNotAssigned();
        }

        public void Unassign(int driverId)
        {
            Driver driver = _driverRepository.GetById(driverId);
            driver.Car = null;
            driver.Shift = null;
            driver.CarId = null;
            _driverRepository.Update(driver);
        }

        public void Update(Driver driver)
        {
            _driverRepository.Update(driver);
        }

        public void UpdateInfo(Driver driver)
        {
            _driverRepository.UpdateInfo(driver);
        }
    }
}
