using TaxiManager.Models.Models;
using TaxiManager.DataAccess.Repositories;
using TaxiManager.DataAccess.Repositories.Interfaces;
using TaxiManager.Services.Interfaces;

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

        public List<Driver> GetAll()
        {
            return _driverRepository.GetAll();
        }

        public Driver GetById(int id)
        {
            return _driverRepository.GetById(id);
        }
    }
}
