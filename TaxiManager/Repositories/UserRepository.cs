using TaxiManager.Exceptions;
using TaxiManager.Models;
using TaxiManager.Repositories.Data;
using TaxiManager.Repositories.Interfaces;

namespace TaxiManager.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            using var context = new TaxiManagerContext();
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            using var context = new TaxiManagerContext();
            User userToDelete = context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (userToDelete == null)
                throw new NoDataFoundException($"No user with given id:{id}");
            context.Users.Remove(userToDelete);
            context.SaveChanges();
        }

        public List<User> GetAll()
        {
            using var context = new TaxiManagerContext();
            return context.Users.ToList();
        }

        public User GetById(int id)
        {
            using var context = new TaxiManagerContext();
            User user = context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                throw new NoDataFoundException($"No user with given id:{id}");
            return user;
        }

        public User GetByUsername(string username)
        {
            using var context = new TaxiManagerContext();
            User user = context.Users.FirstOrDefault(x => x.Username == username);
            if (user == null)
                throw new NoDataFoundException($"No user with given username:{username}");
            return user;
        }

        public void Update(User user)
        {
            using var context = new TaxiManagerContext();
            User userToUpdate = context.Users.FirstOrDefault(x => x.Id == user.Id);
            if (userToUpdate == null)
                throw new NoDataFoundException($"No user was found with id:{user.Id}");
            userToUpdate = user;
            context.SaveChanges();
        }
    }
}
