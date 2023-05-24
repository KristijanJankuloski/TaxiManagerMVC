﻿using TaxiManager.Models.Models;

namespace TaxiManager.Services.Interfaces
{
    public interface IDriverService
    {
        void Add(Driver driver);
        List<Driver> GetAll();
        Driver GetById(int id);
        void Update(Driver driver);
        void DeleteById(int id);
        List<Driver> GetNotAssigned();
    }
}
