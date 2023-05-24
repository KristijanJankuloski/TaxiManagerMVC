//using TaxiManager.Models.Exceptions;
//using TaxiManager.Models.Models;
//using TaxiManager.DataAccess.Repositories.Data;
//using TaxiManager.DataAccess.Repositories.Interfaces;

//namespace TaxiManager.DataAccess.Repositories
//{
//    public class UserRepository : IUserRepository
//    {
//        private readonly TaxiManagerContext _context;
//        public UserRepository(TaxiManagerContext context)
//        {
//            _context = context;
//        }

//        public void Add(User user)
//        {
//            _context.Users.Add(user);
//            _context.SaveChanges();
//        }

//        public void DeleteById(int id)
//        {
//            User userToDelete = _context.Users.Where(x => x.Id == id).FirstOrDefault();
//            if (userToDelete == null)
//                throw new NoDataFoundException($"No user with given id:{id}");
//            _context.Users.Remove(userToDelete);
//            _context.SaveChanges();
//        }

//        public List<User> GetAll()
//        {
//            return _context.Users.ToList();
//        }

//        public User GetById(int id)
//        {
//            User user = _context.Users.FirstOrDefault(x => x.Id == id);
//            if (user == null)
//                throw new NoDataFoundException($"No user with given id:{id}");
//            return user;
//        }

//        public User GetByUsername(string username)
//        {
//            User user = _context.Users.FirstOrDefault(x => x.Username == username);
//            if (user == null)
//                throw new NoDataFoundException($"No user with given username:{username}");
//            return user;
//        }

//        public void Update(User user)
//        {
//            User userToUpdate = _context.Users.FirstOrDefault(x => x.Id == user.Id);
//            if (userToUpdate == null)
//                throw new NoDataFoundException($"No user was found with id:{user.Id}");
//            userToUpdate = user;
//            _context.SaveChanges();
//        }
//    }
//}
