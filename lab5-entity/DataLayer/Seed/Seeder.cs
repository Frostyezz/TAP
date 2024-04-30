using DataLayer.Models;

namespace DataLayer
{
    public static class Seeder
    {
        public static void Seed(MyDbContext context)
        {
            SeedSpecifications(context);
            SeedLaptops(context);
            SeedVehicles(context);
            SeedPassengers(context);
            SeedMusicians(context);
            SeedInstruments(context);

        }

        private static void SeedSpecifications(MyDbContext context)
        {
            if (!context.LaptopSpecifications.Any())
            {
                context.LaptopSpecifications.AddRange(
                    new Specifications(Guid.NewGuid(), "Intel i7", "Nvidia GTX 1660", 16, Guid.NewGuid()),
                    new Specifications(Guid.NewGuid(), "AMD Ryzen 5", "Nvidia RTX 4070", 8, Guid.NewGuid())
                );
                context.SaveChanges();
            }
        }

        private static void SeedLaptops(MyDbContext context)
        {
            if (!context.Laptops.Any())
            {
                var specs1 = context.LaptopSpecifications.First();
                var specs2 = context.LaptopSpecifications.Skip(1).First();

                context.Laptops.AddRange(
                    new Laptop(Guid.NewGuid(), "Dell XPS", specs1.SpecificationsId),
                    new Laptop(Guid.NewGuid(), "HP Pavilion", specs2.SpecificationsId)
                );
                context.SaveChanges();
            }
        }

        private static void SeedVehicles(MyDbContext context)
        {
            if (!context.Vehicles.Any())
            {
                context.Vehicles.AddRange(
                    new Vehicle(Guid.NewGuid(), "Car"),
                    new Vehicle(Guid.NewGuid(), "Motorcycle")
                );
                context.SaveChanges();
            }
        }

        private static void SeedPassengers(MyDbContext context)
        {
            if (!context.Passengers.Any())
            {
                var vehicle1 = context.Vehicles.First();
                var vehicle2 = context.Vehicles.Skip(1).First();

                context.Passengers.AddRange(
                    new Passenger(Guid.NewGuid(), "Sarah", vehicle1.VehicleId),
                    new Passenger(Guid.NewGuid(), "Chris", vehicle2.VehicleId)
                );
                context.SaveChanges();
            }
        }

        private static void SeedMusicians(MyDbContext context)
        {
            if (!context.Musicians.Any())
            {
                context.Musicians.AddRange(
                    new Musician(Guid.NewGuid(), "Harry"),
                    new Musician(Guid.NewGuid(), "Larry")
                );
                context.SaveChanges();
            }
        }

        private static void SeedInstruments(MyDbContext context)
        {
            if (!context.Instruments.Any())
            {
                context.Instruments.AddRange(
                    new Instrument(Guid.NewGuid(), "Guitar"),
                    new Instrument(Guid.NewGuid(), "Drums")
                );
                context.SaveChanges();
            }
        }
    }
}
