using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaxiManager.Models.Models;

namespace TaxiManager.DataAccess.Repositories.Data
{
    public class TaxiManagerContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;

        public TaxiManagerContext(DbContextOptions<TaxiManagerContext> options) : base(options){}
    }
}
