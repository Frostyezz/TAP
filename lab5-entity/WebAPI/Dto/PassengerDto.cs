using DataLayer.Models;

namespace WebAPI.Dto;

public class PassengerDto
{
    public Guid PassengerId { get; set; }
    public Guid VehicleId { get; set; }
    public string PassengerName { get; set; }
}
