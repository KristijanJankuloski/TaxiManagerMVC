using Microsoft.EntityFrameworkCore;
using TaxiManager.Exceptions;
using TaxiManager.Models;
using TaxiManager.Repositories.Data;
using TaxiManager.Repositories.Interfaces;

namespace TaxiManager.Repositories
{
    public class CarRepository : ICarRepository
    {
        public void Add(Car car)
        {
            using var context = new TaxiManagerContext();
            context.Cars.Add(car);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            using var context = new TaxiManagerContext();
            Car? car = context.Cars.Where(x => x.Id == id).FirstOrDefault();
            if (car == null)
                throw new NoDataFoundException($"No car found with id:{id}");
            context.Cars.Remove(car);
            context.SaveChanges();
        }

        public List<Car> GetAll()
        {
            using var context = new TaxiManagerContext();
            return context.Cars.Include(c => c.AssignedDrivers).ToList();
        }

        public List<Car> GetAvailable()
        {
            using var context = new TaxiManagerContext();
            return context.Cars.Include(c => c.AssignedDrivers).Where(x => x.AssignedDrivers.Count < 3).ToList();
        }

        public Car GetById(int id)
        {
            using var context = new TaxiManagerContext();
            Car? car = context.Cars.Include(c => c.AssignedDrivers).FirstOrDefault(x => x.Id == id);
            if (car == null)
                throw new NoDataFoundException($"No car found matching id:{id}");
            return car;
        }

        public void Update(Car car)
        {
            using var context = new TaxiManagerContext();
            Car? carToEdit = context.Cars.FirstOrDefault(x => x.Id == car.Id);
            if (carToEdit == null)
                throw new NoDataFoundException($"No car found matching: {car.Id}");
            carToEdit = car;
            context.SaveChanges();
        }
    }
}
