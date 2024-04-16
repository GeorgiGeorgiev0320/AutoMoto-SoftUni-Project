using System.Reflection;
using CarSelling.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarSelling.Data
{
    public class CarSellingDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public CarSellingDbContext(DbContextOptions<CarSellingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Make> Makes { get; set; } = null!;
        public DbSet<Seller> Sellers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly assemConfig = Assembly.GetAssembly(typeof(CarSellingDbContext)) ??
                                 Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(assemConfig);

            base.OnModelCreating(builder);
        }
    }
}