using TaxiManager.Models.Models;

namespace TaxiManager.Services.Interfaces
{
    public interface IDriverService
    {
        void Add(Driver driver);
        List<Driver> GetAll();
        Driver GetById(int id);
    }
}
