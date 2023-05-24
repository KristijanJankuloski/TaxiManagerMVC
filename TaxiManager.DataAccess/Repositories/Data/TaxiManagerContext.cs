using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaxiManager.Models.Models;

namespace TaxiManager.DataAccess.Repositories.Data
{
    public class TaxiManagerContext : IdentityDbContext<IdentityUser>
    {
        //public DbSet<User> Users { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;

        public TaxiManagerContext(DbContextOptions<TaxiManagerContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
