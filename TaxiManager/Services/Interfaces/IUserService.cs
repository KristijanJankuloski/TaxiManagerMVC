using TaxiManager.Models.Models;

namespace TaxiManager.Services.Interfaces
{
    public interface IUserService
    {
        void Add(User user);
        List<User> GetAll();
        User GetById(int id);
        User GetByUsername(string username);
        User Login(string username, string password);
        void ChangePassowrd(string username, string oldPassword, string newPassword);
        void DeleteById(int id);
    }
}
