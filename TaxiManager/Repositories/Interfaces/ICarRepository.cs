using TaxiManager.Models;

namespace TaxiManager.Repositories.Interfaces
{
    public interface ICarRepository
    {
        void Add(Car car);
        List<Car> GetAll();
        Car GetById(int id);
        void DeleteById(int id);
        void Update(Car car);
        List<Car> GetAvailable();
    }
}
