using TaxiManager.Models;
using TaxiManager.Repositories;
using TaxiManager.Repositories.Interfaces;
using TaxiManager.Services.Interfaces;

namespace TaxiManager.Services
{
    public class DriverService : IDriverService
    {
        private IDriverRepository _driverRepository;

        public DriverService()
        {
            _driverRepository = new DriverRepository();
        }

        public void Add(Driver driver)
        {
            throw new NotImplementedException();
        }

        public List<Driver> GetAll()
        {
            throw new NotImplementedException();
        }

        public Driver GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
