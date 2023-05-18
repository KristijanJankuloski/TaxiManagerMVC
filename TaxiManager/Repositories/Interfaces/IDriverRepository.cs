using TaxiManager.Models;

namespace TaxiManager.Repositories.Interfaces
{
    public interface IDriverRepository
    {
        void Add(Driver driver);
        List<Driver> GetAll();
        Driver GetById(int id);
        void DeleteById(int id);
        void Update(Driver driver);
    }
}
