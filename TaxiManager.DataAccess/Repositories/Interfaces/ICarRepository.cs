using TaxiManager.Models.Models;

namespace TaxiManager.DataAccess.Repositories.Interfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        //void Add(Car car);
        //List<Car> GetAll();
        //Car GetById(int id);
        //void DeleteById(int id);
        //void Update(Car car);
        List<Car> GetAvailable();
    }
}
