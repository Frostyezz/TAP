namespace DataLayer.Models
{
    public class Passenger
    {
        public Passenger(Guid passengerId, string passengerName, Guid vehicleId)
        {
            PassengerId = passengerId;
            PassengerName = passengerName;
            VehicleId = vehicleId;
        }
        public Guid PassengerId { get; set; }
        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public string PassengerName { get; set; }
    }
}
