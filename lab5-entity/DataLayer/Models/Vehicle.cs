namespace DataLayer.Models
{
    public class Vehicle
    {
        public Vehicle(Guid vehicleId, string vehicleType)
        {
            VehicleId = vehicleId;
            VehicleType = vehicleType;
            Passengers = new List<Passenger>();
        }
        public Guid VehicleId { get; set; }
        public string VehicleType { get; set; }

        public ICollection<Passenger> Passengers { get; set; } // 2. ii
    }
}
