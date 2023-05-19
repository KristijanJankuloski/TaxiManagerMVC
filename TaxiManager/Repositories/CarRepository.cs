using Microsoft.EntityFrameworkCore;
using TaxiManager.Exceptions;
using TaxiManager.Models;
using TaxiManager.Repositories.Data;
using TaxiManager.Repositories.Interfaces;

namespace TaxiManager.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly TaxiManagerContext _context;

        public CarRepository(TaxiManagerContext context)
        {
            _context = context;
        }
        public void Add(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Car? car = _context.Cars.Where(x => x.Id == id).FirstOrDefault();
            if (car == null)
                throw new NoDataFoundException($"No car found with id:{id}");
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }

        public List<Car> GetAll()
        {
            return _context.Cars.Include(c => c.AssignedDrivers).ToList();
        }

        public List<Car> GetAvailable()
        {
            return _context.Cars.Include(c => c.AssignedDrivers).Where(x => x.AssignedDrivers.Count < 3).ToList();
        }

        public Car GetById(int id)
        {
            Car? car = _context.Cars.Include(c => c.AssignedDrivers).FirstOrDefault(x => x.Id == id);
            if (car == null)
                throw new NoDataFoundException($"No car found matching id:{id}");
            return car;
        }

        public void Update(Car car)
        {
            Car? carToEdit = _context.Cars.FirstOrDefault(x => x.Id == car.Id);
            if (carToEdit == null)
                throw new NoDataFoundException($"No car found matching: {car.Id}");
            carToEdit = car;
            _context.SaveChanges();
        }
    }
}
