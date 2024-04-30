using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Emit;
using System.Xml;

namespace DataLayer
{
    // dotnet ef migrations add Initial
    // dotnet ef database update
    public class MyDbContext : DbContext
    {
        // 1
        private readonly string _windowsConnectionString = @"Server=localhost\SQLEXPRESS;Database=Lab5;Trusted_Connection=True;TrustServerCertificate=True;";
        //private readonly string _windowsConnectionString = @"Server=localhost\SQLEXPRESS;Database=Lab5Database1;Trusted_Connection=True;TrustServerCertificate=True;";

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Specifications> LaptopSpecifications { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Instrument> Instruments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_windowsConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne(f => f.Type)
                .WithMany(c => c.Users)
                .HasForeignKey(f => f.TypeId);

            builder.Entity<Laptop>()
                .HasOne(h => h.Specifications)
                .WithOne(h => h.Laptop)
                .HasForeignKey<Specifications>(h => h.LaptopId);

            builder.Entity<Vehicle>()
                .HasMany(h => h.Passengers)
                .WithOne(h => h.Vehicle)
                .HasForeignKey(h => h.VehicleId);

            builder.Entity<Musician>()
                .HasMany(h => h.Instruments)
                .WithMany(h => h.Musicians)
                .UsingEntity(h => h.ToTable("MusicianInstrument"));
        }
    }
}
