using GasPOS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GasPOS.Db
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<CustomersOrder> CustomersOrders { get; set; }
        public DbSet<Cynlinder> Cynlinders { get; set; }
        public DbSet<CynlinderCategory> CynlinderCategories { get; set; }
    }
}
