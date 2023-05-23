using TaxiManager.Models.Models;

namespace TaxiManager.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        List<User> GetAll();
        User GetById(int id);
        User GetByUsername(string username);
        void DeleteById(int id);
        void Update(User user);
    }
}
