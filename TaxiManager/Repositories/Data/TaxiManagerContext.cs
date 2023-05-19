using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaxiManager.Models;

namespace TaxiManager.Repositories.Data
{
    public class TaxiManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;

        public TaxiManagerContext(DbContextOptions<TaxiManagerContext> options) : base(options){}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connectionString = "";
        //    var config = new ConfigurationBuilder().Build();
        //    connectionString = config.GetConnectionString("TaxiManagerDatabase");
        //    optionsBuilder.UseSqlServer(connectionString);
        //}
    }
}
