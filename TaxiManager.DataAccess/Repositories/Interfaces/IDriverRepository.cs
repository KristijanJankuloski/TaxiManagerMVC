using TaxiManager.Models.Models;

namespace TaxiManager.DataAccess.Repositories.Interfaces
{
    public interface IDriverRepository : IRepository<Driver>
    {
        //void Add(Driver driver);
        //List<Driver> GetAll();
        //Driver GetById(int id);
        //void DeleteById(int id);
        //void Update(Driver driver);
        void UpdateInfo(Driver driver);
        List<Driver> GetNotAssigned();
        List<Driver> GetAssigned();
    }
}
