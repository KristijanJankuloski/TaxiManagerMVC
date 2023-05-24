using TaxiManager.Models.Exceptions;
using TaxiManager.Models.Models;
using TaxiManager.DataAccess.Repositories.Data;
using TaxiManager.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TaxiManager.DataAccess.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly TaxiManagerContext _context;
        public DriverRepository(TaxiManagerContext context)
        {
            _context = context;
        }

        public void Add(Driver driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Driver driverToDelete = _context.Drivers.FirstOrDefault(x => x.Id == id);
            if (driverToDelete == null)
                throw new NoDataFoundException($"No driver found with id:{id}");
            _context.Drivers.Remove(driverToDelete);
            _context.SaveChanges();
        }

        public List<Driver> GetAll()
        {
            return _context.Drivers.Include(x => x.Car).ToList();
        }

        public List<Driver> GetAssigned()
        {
            return _context.Drivers.Include(d => d.Car).Where(d => d.CarId != null).ToList();
        }

        public Driver GetById(int id)
        {
            Driver driver = _context.Drivers.Include(x => x.Car).FirstOrDefault(x => x.Id == id);
            if (driver == null)
                throw new NoDataFoundException($"No driver found with id:{id}");
            return driver;
        }

        public List<Driver> GetNotAssigned()
        {
            return _context.Drivers.Where(d => d.CarId == null).ToList();
        }

        public void UpdateInfo(Driver driver)
        {
            Driver driverToEdit = _context.Drivers.FirstOrDefault(x => x.Id == driver.Id);
            if (driverToEdit == null)
                throw new NoDataFoundException($"No driver found with id:{driver.Id}");
            driverToEdit.FirstName = driver.FirstName;
            driverToEdit.LastName = driver.LastName;
            driverToEdit.TaxiLicense = driver.TaxiLicense;
            driverToEdit.LicenseExpDate = driver.LicenseExpDate;
            _context.Drivers.Update(driverToEdit);
            _context.SaveChanges();
        }

        public void Update(Driver driver)
        {
            Driver driverToEdit = _context.Drivers.FirstOrDefault(x => x.Id == driver.Id);
            if (driverToEdit == null)
                throw new NoDataFoundException($"No driver found with id:{driver.Id}");
            driverToEdit = driver;
            _context.Drivers.Update(driverToEdit);
            _context.SaveChanges();
        }
    }
}
