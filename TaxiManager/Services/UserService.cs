using BCrypt.Net;
using TaxiManager.Models;
using TaxiManager.Repositories;
using TaxiManager.Repositories.Interfaces;
using TaxiManager.Services.Interfaces;

namespace TaxiManager.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public void Add(User user)
        {
            string passowrdHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = passowrdHash;
            _userRepository.Add(user);
        }

        public void ChangePassowrd(string username, string oldPassword, string newPassword)
        {
            User user = GetByUsername(username);
            if (!BCrypt.Net.BCrypt.Verify(oldPassword, user.Password))
                throw new Exception("Incorrect login information");
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            user.Password = passwordHash;
            _userRepository.Update(user);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetByUsername(string username)
        {
            return _userRepository.GetByUsername(username);
        }

        public User Login(string username, string password)
        {
            User user = GetByUsername(username);
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
                throw new Exception("Incorrect login information");
            return user;
        }
    }
}
