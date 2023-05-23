using TaxiManager.Models.Models;

namespace TaxiManager.Services.Interfaces
{
    public interface ICarService
    {
        void Add(Car car);
        List<Car> GetAll();
        Car GetById(int id);
        void DeleteById(int id);
        List<Car> GetAvailable();
    }
}
