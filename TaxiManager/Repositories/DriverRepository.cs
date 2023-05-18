using TaxiManager.Exceptions;
using TaxiManager.Models;
using TaxiManager.Repositories.Data;
using TaxiManager.Repositories.Interfaces;

namespace TaxiManager.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        public void Add(Driver driver)
        {
            using var context = new TaxiManagerContext();
            context.Drivers.Add(driver);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            using var context = new TaxiManagerContext();
            Driver driverToDelete = context.Drivers.FirstOrDefault(x => x.Id == id);
            if (driverToDelete == null)
                throw new NoDataFoundException($"No driver found with id:{id}");
            context.Drivers.Remove(driverToDelete);
            context.SaveChanges();
        }

        public List<Driver> GetAll()
        {
            using var context = new TaxiManagerContext();
            return context.Drivers.ToList();
        }

        public Driver GetById(int id)
        {
            using var context = new TaxiManagerContext();
            Driver driver = context.Drivers.FirstOrDefault(x => x.Id == id);
            if (driver == null)
                throw new NoDataFoundException($"No driver found with id:{id}");
            return driver;
        }

        public void Update(Driver driver)
        {
            using var context = new TaxiManagerContext();
            Driver driverToEdit = context.Drivers.FirstOrDefault(x => x.Id == driver.Id);
            if (driverToEdit == null)
                throw new NoDataFoundException($"No driver found with id:{driver.Id}");
            driverToEdit = driver;
            context.SaveChanges();
        }
    }
}
